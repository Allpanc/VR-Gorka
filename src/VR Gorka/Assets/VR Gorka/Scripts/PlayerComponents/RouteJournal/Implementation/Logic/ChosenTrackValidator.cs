using System;

namespace VrGorka.RouteJournal.Logic
{
    class ChosenTrackValidator
    {
        public event Action wrongTrackChosen;
        public event Action rightTrackChosen;
        public event Action succesfullyCompleted;
        
        readonly Data.JournalData _journalData;
        
        public ChosenTrackValidator(Data.JournalData journalData)
        {
            _journalData = journalData;
        }

        public void ValidateChosenTrack(string id, int track)
        {
            Data.StatusData statusData = _journalData.statusMap[id];
            statusData.isSwitched = true;
            
            if (track != statusData.targetTrack)
            {
                statusData.chosenTrack = track;
                wrongTrackChosen?.Invoke();
                return;
            }
            
            statusData.chosenTrack = track;
            rightTrackChosen?.Invoke();

            CheckCompleted();
        }

        void CheckCompleted()
        {
            foreach (Data.StatusData statusData in _journalData.statusMap.Values)
            {
                if (!statusData.isSwitched)
                {
                    return;
                }
            }
            
            succesfullyCompleted?.Invoke();
        }
    }
}
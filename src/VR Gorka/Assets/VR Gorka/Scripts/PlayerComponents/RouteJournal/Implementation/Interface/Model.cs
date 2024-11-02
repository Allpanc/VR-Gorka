using System.Collections.Generic;
using System.Linq;

namespace VrGorka.RouteJournal.Interface
{
    class Model : IModel
    {
        private readonly Data.JournalData _journalData;

        public Model(Data.JournalData journalData)
        {
            _journalData = journalData;
        }
        
        public Dictionary<string, Status> GetStatusMap()
        {
            return _journalData.statusMap
                .ToDictionary(
                    x => x.Key,
                    x => x.Value.isSwitched
                        ? x.Value.targetTrack == x.Value.chosenTrack
                            ? Status.Success
                            : Status.Fail
                        : Status.Unset);
        }
    }
}
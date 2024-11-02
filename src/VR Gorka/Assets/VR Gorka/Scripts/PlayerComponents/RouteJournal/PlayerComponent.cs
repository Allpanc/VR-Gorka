using System.Collections.Generic;

namespace VrGorka.RouteJournal
{
    public class PlayerComponent
    {
        public IController controller => _controller;
        public IModel model => _model;
        public IEvents events => _events;
        
        readonly WagonListGeneration.IModel _wagonListGenerationModel;
        readonly IController _controller;
        readonly IEvents _events;
        readonly IModel _model;

        public PlayerComponent(WagonListGeneration.IModel wagonListGenerationModel)
        {
            Data.JournalData journalData = GetJournalData(wagonListGenerationModel);
            
            Logic.ChosenTrackValidator chosenTrackValidator = new Logic.ChosenTrackValidator(journalData);
            
            Interface.Model model = new Interface.Model(journalData);
            Interface.Triggers triggers = new Interface.Triggers();
            Interface.Controller controller = new Interface.Controller(chosenTrackValidator);
            
            _model = model;
            _controller = controller;
            _events = triggers;
            
            chosenTrackValidator.wrongTrackChosen += triggers.RaiseWrongTrackChosen;
            chosenTrackValidator.rightTrackChosen += triggers.RaiseRightTrackChosen;
            chosenTrackValidator.succesfullyCompleted += triggers.RaiseSuccessfullyCompleted;
        }

        Data.JournalData GetJournalData(WagonListGeneration.IModel wagonListGenerationModel)
        {
            var journalData = new Data.JournalData
            {
                statusMap = new Dictionary<string, Data.StatusData>()
            };
            
            foreach (WagonListGeneration.WagonListItemData data in wagonListGenerationModel.wagonListData.items)
            {
               var statusData = new Data.StatusData
                {
                    isSwitched = false,
                    targetTrack = data.targetTrackIndex,
                    chosenTrack = -1
                };
               
                journalData.statusMap[data.wagonId] = statusData;
            }
            
            return journalData;
        }
    }
}
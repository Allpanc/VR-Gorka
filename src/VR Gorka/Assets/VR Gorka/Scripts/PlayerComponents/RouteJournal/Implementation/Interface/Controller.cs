namespace VrGorka.RouteJournal.Interface
{
    class Controller : IController
    {
        readonly Logic.ChosenTrackValidator _chosenTrackValidator;

        public Controller(Logic.ChosenTrackValidator chosenTrackValidator)
        {
            _chosenTrackValidator = chosenTrackValidator;
        }
        
        public void SetChosenTrack(string id, int track)
        {
            _chosenTrackValidator.ValidateChosenTrack(id, track);
        }
    }
}
using System;

namespace VrGorka.RouteJournal.Interface
{
    class Triggers : IEvents
    {
        public event Action wrongTrackChosen;
        public event Action rightTrackChosen;
        public event Action succesfullyCompleted;

        public void RaiseWrongTrackChosen()
        {
            wrongTrackChosen?.Invoke();
        }
        
        public void RaiseRightTrackChosen()
        {
            rightTrackChosen?.Invoke();
        }

        public void RaiseSuccessfullyCompleted()
        {
            succesfullyCompleted?.Invoke();
        }
    }
}
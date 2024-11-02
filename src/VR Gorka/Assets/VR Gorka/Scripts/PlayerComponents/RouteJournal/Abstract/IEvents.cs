using System;

namespace VrGorka.RouteJournal
{
    public interface IEvents
    {
        event Action wrongTrackChosen;
        event Action rightTrackChosen;
        event Action succesfullyCompleted;
    }
}
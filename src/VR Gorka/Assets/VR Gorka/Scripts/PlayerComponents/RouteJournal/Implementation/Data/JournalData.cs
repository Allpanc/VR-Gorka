using System.Collections.Generic;

namespace VrGorka.RouteJournal.Data
{
    class JournalData
    {
        public Dictionary<string, StatusData> statusMap;
    }

    class StatusData
    {
        public bool isSwitched;
        public int targetTrack;
        public int chosenTrack;
    }
}
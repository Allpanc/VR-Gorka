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
            Dictionary<string,Status> statusMap = _journalData.statusMap
                .ToDictionary(
                    x => x.Key,
                    x => x.Value.isSwitched
                        ? x.Value.targetTrack == x.Value.chosenTrack
                            ? Status.Success
                            : Status.Fail
                        : Status.Unset);
            
            return statusMap;
        }

        public int GetWagonsCountOnRoute(int routeIndex)
        {
            return _journalData.statusMap.Values
                .ToList()
                .FindAll(x => x.chosenTrack == routeIndex)
                .Count();
        }
    }
}
using System.Collections.Generic;

namespace VrGorka.RouteJournal
{
    public interface IModel
    {
        Dictionary<string, Status> GetStatusMap();
    }
}
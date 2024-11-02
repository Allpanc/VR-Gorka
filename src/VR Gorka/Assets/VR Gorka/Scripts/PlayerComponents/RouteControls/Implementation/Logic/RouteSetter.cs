using VrGorka.RouteControls.Data;
using VrGorka.RouteFollowers;

namespace VrGorka.RouteControls.Logic
{
    class RouteSetter
    {
        readonly RouteControlsState _state;

        public RouteSetter(Data.RouteControlsState state)
        {
            _state = state;
        }
        
        public void SetActiveRoute(TrainViewGeneration.TrainViewData trainViewData, int routeIndex)
        {
            foreach (TrainViewGeneration.WagonView wagonView in trainViewData.wagonViews)
            {
                IRouteFollower routeFollower = wagonView.routeFollower;
                
                if (routeFollower.isSwitched)
                {
                    continue;
                }
                
                routeFollower.SetRoute(routeIndex);
            }
            
            _state.activeRouteIndex = routeIndex;
        }
    }
}
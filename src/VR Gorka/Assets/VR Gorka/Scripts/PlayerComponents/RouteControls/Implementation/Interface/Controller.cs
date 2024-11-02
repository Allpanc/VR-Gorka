namespace VrGorka.RouteControls.Interface
{
    class Controller : IController
    {
        readonly Logic.RouteSetter _routeSetter;

        public Controller(Logic.RouteSetter routeSetter)
        {
            _routeSetter = routeSetter;
        }
        
        public void SetRoute(TrainViewGeneration.TrainViewData trainViewData, int routeIndex)
        {
            _routeSetter.SetActiveRoute(trainViewData, routeIndex);
        }
    }
}
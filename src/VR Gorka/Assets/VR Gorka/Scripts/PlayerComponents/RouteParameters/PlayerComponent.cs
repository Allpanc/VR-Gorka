using Dreamteck.Splines;

namespace VrGorka.RouteParameters
{
    public class PlayerComponent
    {
        public IRouteParametersProvider routeParametersProvider => _routeParametersProvider;
        
        readonly RouteParametersProvider _routeParametersProvider;

        public PlayerComponent(
            TrainViewGeneration.IModel trainViewModel,
            SplineComputer mainSpline, 
            SplineComputer[] branchSplines)
        {
            var routeParametersProvider = new RouteParametersProvider(trainViewModel, mainSpline, branchSplines);
            
            _routeParametersProvider = routeParametersProvider;
        }
    }
}
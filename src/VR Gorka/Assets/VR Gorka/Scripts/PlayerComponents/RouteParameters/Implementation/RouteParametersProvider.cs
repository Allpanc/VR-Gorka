using Dreamteck.Splines;

namespace VrGorka.RouteParameters
{
    class RouteParametersProvider : IRouteParametersProvider
    {
        readonly TrainViewGeneration.IModel _trainViewModel;
        readonly SplineComputer _mainSpline;
        readonly SplineComputer[] _branchSplines;

        public RouteParametersProvider(
            TrainViewGeneration.IModel trainViewModel,
            SplineComputer mainSpline, 
            SplineComputer[] branchSplines)
        {
            _trainViewModel = trainViewModel;
            _mainSpline = mainSpline;
            _branchSplines = branchSplines;
        }
        
        public float GetWagonGapForRoute(int routeIndex)
        {
            float mainSplineLength = _mainSpline.CalculateLength();
            float branchLength = _branchSplines[routeIndex].CalculateLength();

            float relativeLength = mainSplineLength / branchLength;
            
            return _trainViewModel.wagonGap * relativeLength;
        }
    }
}
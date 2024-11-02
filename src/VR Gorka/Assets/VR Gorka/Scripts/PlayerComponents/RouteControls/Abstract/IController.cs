namespace VrGorka.RouteControls
{
    public interface IController
    {
        void SetRoute(TrainViewGeneration.TrainViewData trainViewData, int routeIndex);
    }
}
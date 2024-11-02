namespace VrGorka.RouteControls.Interface
{
    class Model : IModel
    {
        public int activeRoute => _state.activeRouteIndex;
        
        private readonly Data.RouteControlsState _state;

        public Model(Data.RouteControlsState state)
        {
            _state = state;
        }
    }
}
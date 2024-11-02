namespace VrGorka.RouteControls
{
    public class PlayerComponent
    {
        public IController controller => _controller;
        public IModel model => _model;

        Interface.Controller _controller;
        Interface.Model _model;
        
        public PlayerComponent()
        {
            var routeControlsState = new Data.RouteControlsState
            {
                activeRouteIndex = 0
            };

            var routeSetter = new Logic.RouteSetter(routeControlsState);

            var controller = new Interface.Controller(routeSetter);
            var model = new Interface.Model(routeControlsState);
            
            _controller = controller;
            _model = model;
        }
    }
}
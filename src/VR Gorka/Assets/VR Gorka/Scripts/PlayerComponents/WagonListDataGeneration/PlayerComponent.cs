namespace VrGorka.WagonListGeneration
{
    public class PlayerComponent
    {
        public IController controller => _controller;
        public IModel model => _model;
        
        readonly Inrterface.Model _model;
        readonly Inrterface.Controller _controller;

        public PlayerComponent(int tracksCount)
        {
            var wagonListDataGenerator = new Logic.WagonListDataGenerator(tracksCount);

            var model = new Inrterface.Model();
            var controller = new Inrterface.Controller(model, wagonListDataGenerator);
            
            _model = model;
            _controller = controller;
        }
    }
}
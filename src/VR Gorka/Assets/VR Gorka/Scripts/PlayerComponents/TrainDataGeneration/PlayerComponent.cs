using UnityEngine;

namespace VrGorka.TrainDataGeneration
{
    public class PlayerComponent
    {
        public IController controller => _controller;
        public IModel model => _model;
        
        readonly Interface.Controller _controller;
        readonly Interface.Model _model;

        public PlayerComponent()
        {
            TrainConfig trainConfig = Resources.Load<TrainConfig>("TrainConfig");
            
            var trainDataGenerator = new Logic.TrainDataGenerator();
            
            var model = new Interface.Model(trainConfig);
            var controller = new Interface.Controller(model, trainDataGenerator);
            
            _model = model;
            _controller = controller;
        }
    }
}
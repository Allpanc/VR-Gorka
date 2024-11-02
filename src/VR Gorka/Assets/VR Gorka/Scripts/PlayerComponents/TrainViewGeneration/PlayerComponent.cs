using Dreamteck.Splines;
using UnityEngine;

namespace VrGorka.TrainViewGeneration
{
    public class PlayerComponent
    {
        public IController controller => _controller;
        public IModel model => _model;
        
        readonly Interface.Controller _controller;
        readonly Interface.Model _model;

        public PlayerComponent(
            Transform trainParent, 
            SplineComputer mainSpline,
            SplineComputer[] branchSplines,
            Node junction)
        {
            WagonViewConfig wagonViewConfig = Resources.Load<WagonViewConfig>("WagonViewConfig");
            
            var wagonViewFactory = new Logic.WagonViewFactory(
                wagonViewConfig, 
                trainParent, 
                mainSpline,
                branchSplines,
                junction);
            
            var trainViewGenerator = new Logic.TrainViewGenerator(wagonViewFactory);
            
            var model = new Interface.Model(wagonViewConfig);
            var controller = new Interface.Controller(model, trainViewGenerator);
            
            _model = model;
            _controller = controller;
        }
    }
}
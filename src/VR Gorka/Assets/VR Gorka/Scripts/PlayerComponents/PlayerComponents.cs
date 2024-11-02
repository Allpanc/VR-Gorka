using Dreamteck.Splines;
using UnityEngine;

namespace VrGorka.PlayerComponents
{
    public class PlayerComponents
    {
        public class Context
        {
            public Transform trainParent;
            public SplineComputer mainSpline;
            public SplineComputer[] branchSplines;
            public Node junction;
        }

        public TrainDataGeneration.PlayerComponent trainDataGeneratorComponent => _trainDataGeneratorComponent;
        public TrainViewGeneration.PlayerComponent trainViewGeneratorComponent => _trainViewGeneratorComponent;
        public WagonListGeneration.PlayerComponent wagonListGenerationComponent => _wagonListGenerationComponent;
        public RouteControls.PlayerComponent routeControlsComponent => _routeControlsComponent;
        public RouteJournal.PlayerComponent routeJournalComponent => _routeJournalComponent;
        
        readonly TrainDataGeneration.PlayerComponent _trainDataGeneratorComponent;
        readonly TrainViewGeneration.PlayerComponent _trainViewGeneratorComponent;
        readonly WagonListGeneration.PlayerComponent _wagonListGenerationComponent;
        readonly RouteControls.PlayerComponent _routeControlsComponent;
        readonly RouteJournal.PlayerComponent _routeJournalComponent;

        public PlayerComponents(Context context)
        {
            var trainDataGeneratorComponent = new TrainDataGeneration.PlayerComponent();
            trainDataGeneratorComponent.controller.GenerateNewTrainData();
            TrainDataGeneration.TrainData trainData = trainDataGeneratorComponent.model.trainData;

            var trainViewGeneratorComponent = new TrainViewGeneration.PlayerComponent(
                context.trainParent,
                context.mainSpline,
                context.branchSplines,
                context.junction);
            
            trainViewGeneratorComponent.controller.GenerateTrainView(trainData);
            
            var wagonListGenerationComponent
                = new WagonListGeneration.PlayerComponent(context.branchSplines.Length);
            
            wagonListGenerationComponent.controller.GenerateWagonListData(trainData);
            
            var routeControlsComponent = new RouteControls.PlayerComponent();

            var routeJournalComponent = new RouteJournal.PlayerComponent(wagonListGenerationComponent.model);

            _trainDataGeneratorComponent = trainDataGeneratorComponent;
            _trainViewGeneratorComponent = trainViewGeneratorComponent;
            _wagonListGenerationComponent = wagonListGenerationComponent;
            _routeControlsComponent = routeControlsComponent;
            _routeJournalComponent = routeJournalComponent;
        }
    }
}
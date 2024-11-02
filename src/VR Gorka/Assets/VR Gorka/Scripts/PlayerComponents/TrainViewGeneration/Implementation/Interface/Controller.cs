using VrGorka.TrainDataGeneration;

namespace VrGorka.TrainViewGeneration.Interface
{
    class Controller : IController
    {
        readonly IModel _model;
        readonly Logic.TrainViewGenerator _generator;

        public Controller(IModel model, Logic.TrainViewGenerator generator)
        {
            _model = model;
            _generator = generator;
        }
        
        public void GenerateTrainView(TrainData trainData)
        {
            TrainViewData trainViewData = _generator.GenerateTrainView(trainData);
            _model.trainViewData = trainViewData;
        }
    }
}
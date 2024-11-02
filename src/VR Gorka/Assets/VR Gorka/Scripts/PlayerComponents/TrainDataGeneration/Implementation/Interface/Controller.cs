namespace VrGorka.TrainDataGeneration.Interface
{
    class Controller : IController
    {
        private readonly IModel _model;
        readonly Logic.TrainDataGenerator _generator;

        public Controller(IModel model, Logic.TrainDataGenerator generator)
        {
            _model = model;
            _generator = generator;
        }
        
        public void GenerateNewTrainData()
        {
            TrainData trainViewData = _generator.GenerateNewTrainData(_model.wagonsCount);
            
            _model.trainData = trainViewData;
        }
    }
}
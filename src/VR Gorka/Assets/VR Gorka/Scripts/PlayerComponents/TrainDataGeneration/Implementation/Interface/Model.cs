namespace VrGorka.TrainDataGeneration.Interface
{
    class Model : IModel
    {
        TrainData IModel.trainData
        {
            get => _trainData;
            set => _trainData = value;
        }
        
        public int wagonsCount => _trainConfig.wagonsCount;
        
        readonly TrainConfig _trainConfig;
        
        private TrainData _trainData;
        
        public Model(TrainConfig trainConfig)
        {
            _trainConfig = trainConfig;
        }
    }
}
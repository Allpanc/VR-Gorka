namespace VrGorka.TrainViewGeneration.Interface
{
    class Model : IModel
    {
        TrainViewData IModel.trainViewData
        {
            get => _trainViewData;
            set => _trainViewData = value;
        }

        public float timeBetweenWagons => _wagonViewConfig.timeBetweenWagons;
        public float wagonsSpeed => _wagonViewConfig.wagonsSpeed;

        TrainViewData _trainViewData;
        
        readonly WagonViewConfig _wagonViewConfig;
        
        public Model(WagonViewConfig wagonViewConfig)
        {
            _wagonViewConfig = wagonViewConfig;
        }
    }
}
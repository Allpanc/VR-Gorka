namespace VrGorka.TrainViewGeneration.Logic
{
    class TrainViewGenerator
    {
        private readonly WagonViewFactory wagonViewFactory;

        public TrainViewGenerator(WagonViewFactory wagonViewFactory)
        {
            this.wagonViewFactory = wagonViewFactory;
        }
        
        public TrainViewData GenerateTrainView(TrainDataGeneration.TrainData trainData)
        {
            var trainViewData = new TrainViewData
            {
                wagonViews = new()
            };
            
            foreach (TrainDataGeneration.WagonData wagonData in trainData.wagons)
            {
                WagonView wagonView = wagonViewFactory.Create(wagonData);
                trainViewData.wagonViews.Add(wagonView);
            }

            return trainViewData;
        }
    }
}
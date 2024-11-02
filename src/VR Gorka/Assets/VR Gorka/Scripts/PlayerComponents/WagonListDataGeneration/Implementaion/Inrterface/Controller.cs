using VrGorka.TrainDataGeneration;

namespace VrGorka.WagonListGeneration.Inrterface
{
    class Controller : IController
    {
        readonly IModel _model;
        readonly Logic.WagonListDataGenerator _wagonListDataGenerator;

        public Controller(IModel model, Logic.WagonListDataGenerator wagonListDataGenerator)
        {
            _model = model;
            _wagonListDataGenerator = wagonListDataGenerator;
        }
        
        public void GenerateWagonListData(TrainData trainData)
        {
            WagonListData wagonListData = _wagonListDataGenerator.GenerateWagonListData(trainData);
            _model.wagonListData = wagonListData;
        }
    }
}
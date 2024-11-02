namespace VrGorka.WagonListGeneration.Inrterface
{
    public class Model : IModel
    {
        WagonListData IModel.wagonListData
        {
            get => _wagonListData;
            set => _wagonListData = value;
        }

        private WagonListData _wagonListData;
    }
}
namespace VrGorka.TrainDataGeneration
{
    public interface IModel
    {
        TrainData trainData { get; internal set; }
        int wagonsCount { get; }
    }
}
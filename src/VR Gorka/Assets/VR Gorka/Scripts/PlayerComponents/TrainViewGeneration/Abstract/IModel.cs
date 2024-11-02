namespace VrGorka.TrainViewGeneration
{
    public interface IModel
    {
        TrainViewData trainViewData { get; internal set; }
        float timeBetweenWagons { get; }
        float wagonsSpeed { get; }
    }
}
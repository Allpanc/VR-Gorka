namespace VrGorka.Brakes
{
    public interface IBrakeable
    {
        bool isSlowedDown { get; }
        void SlowDown();
    }
}
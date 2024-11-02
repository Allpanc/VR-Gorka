namespace VrGorka.RouteStop
{
    public interface IRouteStopper
    {
        bool isActive { get; set; }
        void Construct(Movables.IMovable movable);
        void SetStopPercent(float stopPercent);
    }
}
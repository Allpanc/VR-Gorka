using Dreamteck.Splines;
using UnityEngine;
using VrGorka.Movables;

namespace VrGorka.RouteStop
{
    public class RouteStopper : MonoBehaviour, IRouteStopper
    {
        public bool isActive 
        { 
            get => _isActive;
            set
            {
                if (value)
                {
                    _splineFollower.onMotionApplied += HandleMotionApplied;
                }
                else
                {
                    _splineFollower.onMotionApplied -= HandleMotionApplied;
                }
                
                _isActive = value;
            }
        }

        [SerializeField] SplineFollower _splineFollower;

        double _stopPercent;

        bool _isActive;
        IMovable _movable;

        public void Construct(IMovable movable)
        {
            _movable = movable;
        }
        
        public void SetStopPercent(float stopPercent)
        {
            _stopPercent = stopPercent;
        }

        void HandleMotionApplied()
        {
            double percent = _splineFollower.GetPercent();

            if (percent < _stopPercent)
            {
                return;
            }
            
            _movable.StopMovement();
        }
    }
}
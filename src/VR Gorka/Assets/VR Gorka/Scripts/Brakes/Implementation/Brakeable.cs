using Dreamteck.Splines;
using UnityEngine;

namespace VrGorka.Brakes
{
    [RequireComponent(typeof(Collider))]
    class Brakeable : MonoBehaviour, IBrakeable
    {
        public bool isSlowedDown => _isSlowedDown;

        [SerializeField] SplineFollower _splineFollower;
        [SerializeField][Range(0,1)] float slowDownPercent;
        
        bool _isSlowedDown;
        
        public void SlowDown()
        {
            float currentSpeed = _splineFollower.followSpeed;
            float targetSpeed = currentSpeed * (1 - slowDownPercent);
            
            _splineFollower.followSpeed = targetSpeed;
            _isSlowedDown = true;
        }
    }
}
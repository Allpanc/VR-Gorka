using Dreamteck.Splines;
using UnityEngine;

namespace VrGorka.Movables
{
    class SplineBasedMovable : MonoBehaviour, IMovable
    {
        [SerializeField] SplineFollower _splineFollower;

        float _speed;
        
        public void StartMovement(float speed)
        {
            _splineFollower.followSpeed = speed;
            _speed = speed;
        }

        public void StopMovement()
        {
            _splineFollower.followSpeed = 0;
        }
    }
}
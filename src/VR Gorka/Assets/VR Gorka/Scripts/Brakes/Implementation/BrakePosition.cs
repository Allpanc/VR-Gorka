using UnityEngine;

namespace VrGorka.Brakes
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    class BrakePosition : MonoBehaviour, IBrakePosition
    {
        private void OnTriggerEnter(Collider other)
        {
            IBrakeable brakeable = other.GetComponent<IBrakeable>();

            if (brakeable == null)
            {
                return;
            }

            if (brakeable.isSlowedDown)
            {
                return;
            }
            
            brakeable.SlowDown();
        }
    }
}
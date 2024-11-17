using DG.Tweening;
using UnityEngine;

namespace VrGorka.UI
{
    public class RouteControlAnimator : MonoBehaviour
    {
        [SerializeField] private Transform _buttonTransform;
        [SerializeField] private float _amplitude;
        [SerializeField] private float _duration;

        private Vector3 _pressedPosition;
        private Vector3 _releasedPosition;
        private bool _positionsCached;
        
        public void PlayPressed()
        {
            CacheInitialPosition();
            MoveToPosition(_pressedPosition);
        }

        public void PlayReleased()
        {
            CacheInitialPosition();
            MoveToPosition(_releasedPosition);
        }

        private void MoveToPosition(Vector3 position)
        {
            _buttonTransform.DOKill();
            _buttonTransform
                .DOLocalMove(position, _duration)
                .SetSpeedBased();
        }
        
        private void CacheInitialPosition()
        {
            if (_positionsCached)
            {
                return;
            }

            _positionsCached = true;
            _releasedPosition = _buttonTransform.localPosition;
            _pressedPosition = _releasedPosition + Vector3.back * _amplitude;
        }
    }
}
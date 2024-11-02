using System;
using System.Collections;
using Dreamteck.Splines;
using UnityEngine;

namespace VrGorka.RouteFollowers
{
    public class RouteSwitcher : MonoBehaviour
    {
        public event Action splineEndReached;
        
        public SplineComputer currentSpline => _follower.spline;

        [SerializeField] SplineFollower _follower;

        double _lastPercent;
        
        void Start()
        {
            _follower.onMotionApplied += OnMotionApplied;
            _follower.onBeginningReached += OnBeginningReached;
            _follower.onEndReached += OnEndReached;
        }
        
        public void Prepare(SplineComputer spline, float splinePercent)
        {
            _follower.spline = spline;
            StartCoroutine(SetPercent(splinePercent));
        }

        private IEnumerator SetPercent(float splinePercent)
        {
            yield return null;
            _follower.SetPercent(splinePercent);
        }

        public void SwitchSpline(Node.Connection from, Node.Connection to)
        {
            float excessDistance = GetExcessDistance(from);

            _follower.spline = to.spline;
            _follower.RebuildImmediate();
            
            double startPercent = _follower.ClipPercent(to.spline.GetPointPercent(to.pointIndex));
        
            if (Vector3.Dot(from.spline.Evaluate(from.pointIndex).forward, to.spline.Evaluate(to.pointIndex).forward) < 0f)
            {
                _follower.direction = IsFollowerMovingForward() 
                    ? Spline.Direction.Backward 
                    : Spline.Direction.Forward;
            }
        
            _follower.SetPercent(_follower.Travel(startPercent, excessDistance, _follower.direction));
        }

        void OnBeginningReached(double lastPercent)
        {
            _lastPercent = lastPercent;
        }

        void OnEndReached(double lastPercent)
        {
            splineEndReached?.Invoke();
            _lastPercent = lastPercent;
        }

        void OnMotionApplied()
        {
            _lastPercent = _follower.result.percent;
        }

        float GetExcessDistance(Node.Connection from)
        {
            return from.spline.CalculateLength(from.spline.GetPointPercent(from.pointIndex), _follower.UnclipPercent(_lastPercent));
        }

        bool IsFollowerMovingForward()
        {
            return _follower.direction == Spline.Direction.Forward;
        }
    }
}
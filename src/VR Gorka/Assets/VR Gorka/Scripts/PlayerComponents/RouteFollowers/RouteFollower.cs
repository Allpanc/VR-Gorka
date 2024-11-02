using System;
using System.Linq;
using Dreamteck.Splines;
using UnityEngine;

namespace VrGorka.RouteFollowers
{
    class RouteFollower : MonoBehaviour, IRouteFollower
    {
        public event Action<int> routeSwitched;
        public bool isSwitched { get; private set; }
        
        [SerializeField] RouteSwitcher _routeSwitcher;
        
        Node.Connection currentConnection;
        Node.Connection _targetConnection;
        Node _junction;
        SplineComputer[] _branchSplines;
        int _routeIndex;
        
        public void Prepare(IRouteFollower.Context context)
        {
            _routeSwitcher.Prepare(context.mainSpline, context.splinePercent);
            _junction = context.junction;
            _branchSplines = context.branchSplines;
        }

        public void SetRoute(int routeIndex)
        {
            _routeIndex = routeIndex;
            _routeSwitcher.splineEndReached -= HandleSplineEndReached;
            
            var connections = _junction.GetConnections().ToList();
            
            var currentSpline = _routeSwitcher.currentSpline;
            var targetSpline = _branchSplines[_routeIndex];
            
            currentConnection = connections.Find(x => x.spline == currentSpline);
            _targetConnection = connections.Find(x => x.spline == targetSpline);
            
            _routeSwitcher.splineEndReached += HandleSplineEndReached;
        }

        private void HandleSplineEndReached()
        {
            _routeSwitcher.splineEndReached -= HandleSplineEndReached;
            
            _routeSwitcher.SwitchSpline(currentConnection, _targetConnection);
            routeSwitched?.Invoke(_routeIndex);
            isSwitched = true;
        }
    }
}
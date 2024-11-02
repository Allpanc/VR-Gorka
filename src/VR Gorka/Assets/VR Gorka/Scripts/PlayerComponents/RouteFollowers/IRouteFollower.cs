using System;
using Dreamteck.Splines;

namespace VrGorka.RouteFollowers
{
    public interface IRouteFollower
    {
        public class Context
        {
            public SplineComputer mainSpline;
            public SplineComputer[] branchSplines;
            public Node junction;
            public float splinePercent;
        }

        event Action<int> routeSwitched;
        bool isSwitched { get; }
        void Prepare(Context context);
        void SetRoute(int routeIndex);
    }
}
using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;
using UnityEngine;

namespace VrGorka.TrainViewGeneration.Logic
{
    class WagonViewFactory
    {
        readonly Transform _trainParent;
        readonly SplineComputer _mainSpline;
        readonly SplineComputer[] _branchSplines;
        readonly Node _junction;
        readonly Dictionary<TrainDataGeneration.WagonType, WagonView> _prefabMap;
        readonly float _wagonGap;
        float _currentPercent;

        public WagonViewFactory(
            WagonViewConfig wagonViewConfig, 
            Transform trainParent,
            SplineComputer mainSpline,
            SplineComputer[] branchSplines,
            Node junction)
        {
            _trainParent = trainParent;
            _mainSpline = mainSpline;
            _branchSplines = branchSplines;
            _junction = junction;
            _prefabMap = wagonViewConfig.wagonPrefabs
                .ToDictionary(wagonViewData => wagonViewData.type, wagonViewData => wagonViewData.prefab);
            _wagonGap = wagonViewConfig.wagonGap;
        }

        public WagonView Create(TrainDataGeneration.WagonData wagonData)
        {
            WagonView wagonView = Object.Instantiate(_prefabMap[wagonData.type], _trainParent);
            
            wagonView.ShowId(wagonData.id);
            wagonView.routeFollower.Prepare(GetContext());
            wagonView.movable.StopMovement();
            
            return wagonView;
        }

        RouteFollowers.IRouteFollower.Context GetContext()
        {
            return new RouteFollowers.IRouteFollower.Context()
            {
                mainSpline = _mainSpline,
                junction = _junction,
                branchSplines = _branchSplines,
                splinePercent = GetClampedPercent()
            };
        }

        float GetClampedPercent()
        {
            float suggestedPercent = Mathf.Clamp01(_currentPercent + _wagonGap);
            _currentPercent = suggestedPercent;
            
            return _currentPercent;
        }
    }
}
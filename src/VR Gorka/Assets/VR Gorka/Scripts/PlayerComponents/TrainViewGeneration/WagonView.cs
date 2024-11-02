using System;
using TMPro;
using UnityEngine;
using VrGorka.Movables;
using VrGorka.RouteFollowers;
using VrGorka.RouteStop;

namespace VrGorka.TrainViewGeneration
{
    public class WagonView : MonoBehaviour
    {
        public event Action<string, int> routeSwitched;
        
        public IRouteFollower routeFollower
        {
            get
            {
                if (_routeFollower == null)
                {
                    _routeFollower = GetComponent<IRouteFollower>();
                    _routeFollower.routeSwitched += OnRouteSwitched;
                }

                return _routeFollower;
            }
        }

        public IMovable movable => 
            _movable ??= GetComponent<IMovable>();

        public IRouteStopper routeStopper
        {
            get
            {
                if (_routeStopper == null)
                {
                    _routeStopper = GetComponent<IRouteStopper>();
                    _routeStopper.Construct(movable);
                }
                
                return _routeStopper ??= GetComponent<IRouteStopper>();
            }
        }

        public string id => _id;

        [SerializeField] TMP_Text _numberText;

        IRouteFollower _routeFollower;
        IMovable _movable;
        IRouteStopper _routeStopper;

        string _id;

        public void ShowId(string id)
        {
            _id = id;
            _numberText.text = _id;
        }

        private void OnRouteSwitched(int routeIndex)
        {
            routeSwitched?.Invoke(_id, routeIndex);
        }
    }
}
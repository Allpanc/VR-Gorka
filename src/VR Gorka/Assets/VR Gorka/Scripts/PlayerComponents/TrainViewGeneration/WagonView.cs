using System;
using TMPro;
using UnityEngine;
using VrGorka.Movables;
using VrGorka.RouteFollowers;

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

        private void OnRouteSwitched(int routeIndex)
        {
            routeSwitched?.Invoke(_id, routeIndex);
        }

        public IMovable movable => 
            _movable ??= GetComponent<IMovable>();
        
        [SerializeField] TMP_Text _numberText;
        
        IRouteFollower _routeFollower;
        IMovable _movable;
        string _id;
        
        public void ShowId(string id)
        {
            _id = id;
            _numberText.text = _id;
        }
    }
}
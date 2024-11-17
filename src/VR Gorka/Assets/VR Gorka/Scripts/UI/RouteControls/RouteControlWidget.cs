using System;
using UnityEngine;

namespace VrGorka.UI
{
    class RouteControlWidget : MonoBehaviour
    {
        public class Context
        {
            public int routeIndex;
        }

        [Serializable]
        public class SignalLightSettings
        {
            public Material disabledMaterial;
            public Material signalMaterial;
        }

        public bool isHighlighted
        {
            get => _isHighlighted;
            set
            {
                if (_isHighlighted == value)
                {
                    return;
                }
                
                _isHighlighted = value; 
                
                _signalLightMesh.material = _isHighlighted
                    ? _signalLightSettings.signalMaterial
                    : _signalLightSettings.disabledMaterial;

                if (_isHighlighted)
                {
                    _routeControlAnimator.PlayPressed();
                    return;
                }

                _routeControlAnimator.PlayReleased();
            } 
        }
        
        public event Action<int> routeChangeRequired;
        
        [SerializeField] ButtonTrigger _buttonTrigger;
        [SerializeField] MeshRenderer _signalLightMesh;
        [SerializeField] RouteControlAnimator _routeControlAnimator;
        [SerializeField] SignalLightSettings _signalLightSettings;

        private int _routeIndex;
        private bool _isHighlighted;
        
        public void Prepare(Context context)
        {
            _routeIndex = context.routeIndex;
            _buttonTrigger.onClicked += HandleClicked;
        }

        private void HandleClicked()
        {
            routeChangeRequired?.Invoke(_routeIndex);
        }
    }
}
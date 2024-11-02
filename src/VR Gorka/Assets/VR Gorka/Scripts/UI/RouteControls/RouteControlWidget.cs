using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace VrGorka.UI
{
    class RouteControlWidget : MonoBehaviour
    {
        public class Context
        {
            public int routeIndex;
        }

        public bool isOutlined
        {
            get => _outlineImage.enabled;
            set => _outlineImage.enabled = value;
        }
        
        public event Action<int> routeChangeRequired;
        
        [SerializeField] Button _button;
        [SerializeField] TMP_Text _text;
        [SerializeField] Image _outlineImage;

        int _routeIndex;
        
        public void Prepare(Context context)
        {
            _routeIndex = context.routeIndex;
            _text.text = (_routeIndex + 1).ToString();
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            routeChangeRequired?.Invoke(_routeIndex);
        }
    }
}
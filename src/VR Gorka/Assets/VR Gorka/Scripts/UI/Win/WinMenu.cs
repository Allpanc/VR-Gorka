using System;
using UnityEngine;
using UnityEngine.UI;

namespace VrGorka.UI
{
    public class WinMenu : MonoBehaviour
    {
        public event Action restartRequired;
        
        [SerializeField] Button _restartButton;

        void Start()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        void OnRestartButtonClick()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
            restartRequired?.Invoke();
        }
    }
}
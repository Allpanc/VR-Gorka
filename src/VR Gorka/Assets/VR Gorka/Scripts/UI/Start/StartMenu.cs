using System;
using UnityEngine;
using UnityEngine.UI;

namespace VrGorka.UI
{
    public class StartMenu : MonoBehaviour
    {
        public event Action startRequired;
        
        [SerializeField] Button _startButton;

        void Start()
        {
            _startButton.onClick.AddListener(OnStartButtonClick);
        }

        void OnStartButtonClick()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClick);
            startRequired?.Invoke();
        }
    }
}
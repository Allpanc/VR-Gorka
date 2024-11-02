using System;
using UnityEngine;
using UnityEngine.UI;

namespace VrGorka.UI
{
    public class TutorialMenu : MonoBehaviour
    {
        public event Action tutorialCompleted;
        
        [SerializeField] Button _okButton;

        void Start()
        {
            _okButton.onClick.AddListener(OnTutorialButtonClick);
        }

        void OnTutorialButtonClick()
        {
            _okButton.onClick.RemoveListener(OnTutorialButtonClick);
            tutorialCompleted?.Invoke();
        }
    }
}
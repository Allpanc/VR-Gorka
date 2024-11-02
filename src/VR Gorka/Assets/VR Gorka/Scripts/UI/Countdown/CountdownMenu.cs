using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace VrGorka.UI
{
    public class CountdownMenu : MonoBehaviour
    {
        public event Action countdownCompleted;

        [SerializeField] int _duration;
        [SerializeField] TMP_Text _counterText;

        public void StartCountdown()
        {
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            _counterText.text = _duration.ToString();

            while (_duration > 0)
            {
                yield return new WaitForSeconds(1);
                _duration--;
                _counterText.text = _duration.ToString();
            }
            
            countdownCompleted?.Invoke();
        }
    }
}
using System.Collections;
using UnityEngine;

namespace VrGorka.Utils
{
    public class CoroutineRunner : MonoBehaviour
    {
        public Coroutine RunCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }

        public void EndCoroutine(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}

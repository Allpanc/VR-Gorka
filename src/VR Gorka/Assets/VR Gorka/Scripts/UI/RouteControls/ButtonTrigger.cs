using System;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace VrGorka.UI
{
    public class ButtonTrigger : MonoBehaviour
    {
        public event Action onClicked;
        
        private Hand currentHand;

        void TriggerAction()
        {
            onClicked?.Invoke();
        }

        private void OnHandHoverBegin(Hand hand)
        {
            currentHand = hand;
            currentHand.grabPinchAction.onStateDown += HandleStateDown;
        }

        private void OnHandHoverEnd(Hand hand)
        {
            if (currentHand != hand)
            {
                return;
            }

            currentHand.grabPinchAction.onStateDown -= HandleStateDown;
            currentHand = null;
        }

        private void HandleStateDown(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
        {
            TriggerAction();
        }
    }
}
using UnityEngine;
using Valve.VR.InteractionSystem;

public class VrDebugger : MonoBehaviour
{
    [SerializeField] private Interactable _interactable;
    [SerializeField] private InteractableHoverEvents _interactableHoverEvents;

    private void Start()
    {
        _interactable.onAttachedToHand += HandleAttachedToHand;
        _interactable.onDetachedFromHand += HandleDetachedFromHand;
        
        _interactableHoverEvents.onAttachedToHand.AddListener(HandleAttachedToHandHoverEvent);
        _interactableHoverEvents.onDetachedFromHand.AddListener(HandleDetachedFromHandHoverEvent);
        _interactableHoverEvents.onHandHoverBegin.AddListener(HandleHoverBegin);
        _interactableHoverEvents.onHandHoverEnd.AddListener(HandleHoverEnd);
    }

    private void HandleAttachedToHand(Hand hand)
    {
        Debug.Log("Event: Attached to Hand");
    }

    private void HandleDetachedFromHand(Hand hand)
    {
        Debug.Log("Event: Detached from Hand");
    }

    private void HandleDetachedFromHandHoverEvent()
    {
        Debug.Log("Event: Detached from Hand (from InteractableHoverEvents)");
    }

    private void HandleAttachedToHandHoverEvent()
    {
        Debug.Log("Event: Attached to Hand (from InteractableHoverEvents)");
    }

    private void HandleHoverBegin()
    {
        Debug.Log("Event: Hover Begin (from InteractableHoverEvents)");
    }

    private void HandleHoverEnd()
    {
        Debug.Log("Event: Hover End (from InteractableHoverEvents)");
    }
}
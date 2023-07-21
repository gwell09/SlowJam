using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// A sprite that can be used like a button without the need for UI
/// </summary>
public class ClickableSprite : MonoBehaviour
{
    public bool interactable;

    public UnityEvent OnCursorEnter, OnCursorExit, OnCursorRelease, OnObjectClicked;


    private void OnMouseEnter()
    {
        if(interactable)
        {
            OnCursorEnter?.Invoke();
        }
    }

    private void OnMouseExit()
    {
        if (interactable)
        {
            OnCursorExit?.Invoke();
        }

    }

    private void OnMouseDown()
    {
        if (interactable)
        {
            OnObjectClicked?.Invoke();
        }
    }

    private void OnMouseUp()
    {
        if (interactable)
        {
            OnCursorRelease?.Invoke();
        }
    }
}

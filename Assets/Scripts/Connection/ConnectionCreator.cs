using UnityEngine;
using UnityEngine.EventSystems;

public class ConnectionCreator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isRightClicking = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            isRightClicking = true;
            Debug.Log("Right click started on: " + gameObject.name);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            isRightClicking = false;
            Debug.Log("Right click stopped on: " + gameObject.name);
        }
    }
}
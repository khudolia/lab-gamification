using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform dragRectTransform;
    private Canvas canvas;
    private RectTransform canvasRectTransform;

    private Vector2 pointerOffset;

    public bool isDragging = false;
    
    private void Start()
    {
        dragRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasRectTransform = canvas.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
            return;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            dragRectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out pointerOffset);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragRectTransform == null || canvas == null)
            return;
        
        if (eventData.button == PointerEventData.InputButton.Right)
            return;

        isDragging = true;
        
        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out localPointerPosition))
        {
            Vector2 clampedPosition = ClampToScreen(localPointerPosition - pointerOffset);
            dragRectTransform.localPosition = clampedPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Perform any necessary cleanup or additional logic when the dragging ends

        if (isDragging == false && CompareTag("Node") && eventData.button != PointerEventData.InputButton.Right)
        {
            GetComponent<NodeDeletor>().OnPress();
        }
        isDragging = false;
    }

    private Vector2 ClampToScreen(Vector2 position)
    {
        Vector2 minPosition = canvasRectTransform.rect.min + dragRectTransform.rect.size / 2;
        Vector2 maxPosition = canvasRectTransform.rect.max - dragRectTransform.rect.size / 2;

        return new Vector2(
            Mathf.Clamp(position.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(position.y, minPosition.y, maxPosition.y)
        );
    }
}
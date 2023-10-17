using UnityEngine;
using UnityEngine.EventSystems;

public class LookAtCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool _isInside = false;
    public float rotationSpeed = 5f; // Adjust this value to control the rotation speed
    public float rotationStrength = .7f;
    
    void Update()
    {
        var screenPoint = Input.mousePosition;
        screenPoint.z = rotationStrength; //distance of the plane from the camera
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(screenPoint);
        // Draw a debug line to visualize the raycast
        Debug.DrawLine(Camera.main.transform.position, mouse_pos, Color.red);

        
        if (_isInside)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation((transform.position - mouse_pos).normalized );
            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, transform.parent.rotation,
            rotationSpeed * Time.deltaTime);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isInside = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isInside = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorTargetController : MonoBehaviour
{
    private RectTransform uiObjectRectTransform;
    private ConnectionCreator _connectionCreator;
    
    private void Start()
    {
        var connection = GameObject.Find("ConnectionManager");
        _connectionCreator = connection.GetComponent<ConnectionCreator>();
        
        uiObjectRectTransform = GetComponent<RectTransform>();
        
        gameObject.SetActive(false);
    }

    private void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to UI coordinates
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            uiObjectRectTransform.parent as RectTransform,
            mousePosition,
            Camera.main,
            out Vector2 localMousePosition);

        // Set the position of the UI object to the mouse position
        uiObjectRectTransform.localPosition = localMousePosition;
        
    }
}

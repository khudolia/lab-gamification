using System;
using UnityEngine;

public class ConnectionDestroyer : MonoBehaviour
{
    public GameObject selectedObject = null;
    private GameObject  previousSelectedObject = null;

    public NewItemController newItemController;

    private void Update()
    {
        if (selectedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.Delete))
                DestroyConnection();

            // Special case for Apple laptops, where there is no "DEL" button
            if (Input.GetKey(KeyCode.LeftCommand) && Input.GetKey(KeyCode.Backspace))
                DestroyConnection();

            if (Input.GetKeyDown(KeyCode.Escape))
                ClearSelection();
        }
    }

    public void ClearSelection()
    {
        previousSelectedObject = selectedObject;
        selectedObject = null;
    }

    public void ClearSelectionFromUI()
    {
        if (selectedObject.CompareTag("Node"))
        {
            previousSelectedObject = selectedObject;
            selectedObject = null;
        }
    }

    public void Select(GameObject gameObject)
    {
        selectedObject = gameObject;
    }
    
    public void DestroyConnection()
    {
        if(selectedObject != null)
            DestroyObject(selectedObject);
        else if (previousSelectedObject != null)
            DestroyObject(previousSelectedObject);
    }

    private void DestroyObject(GameObject targetObject)
    {
        if (targetObject.GetComponent<ConnectionListener>() != null)
        {
            ConnectionManager.RemoveConnections(ConnectionManager.FindConnections(
                targetObject.GetComponent<RectTransform>()));
            newItemController.ObjectRemoved();
        }
        
        Destroy(targetObject);
    }
}
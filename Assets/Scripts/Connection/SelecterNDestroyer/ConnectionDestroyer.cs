using System;
using UnityEngine;

public class ConnectionDestroyer : MonoBehaviour
{
    public GameObject selectedObject = null;
    private GameObject  previousSelectedObject = null;

    public void ClearSelection()
    {
        previousSelectedObject = selectedObject;
        selectedObject = null;
    }

    public void Select(GameObject gameObject)
    {
        selectedObject = gameObject;
    }
    
    public void DestroyConnection()
    {
        if (previousSelectedObject != null)
            Destroy(previousSelectedObject);
    }
}
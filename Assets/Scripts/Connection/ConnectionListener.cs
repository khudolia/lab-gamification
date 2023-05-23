using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ConnectionListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private ConnectionCreator _connectionCreator;
    private bool isRightClicking = false;

    private void Start()
    {
        var connection = GameObject.Find("ConnectionManager");
        _connectionCreator = connection.GetComponent<ConnectionCreator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            isRightClicking = true;
            
            _connectionCreator.StartConnecting(gameObject);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            isRightClicking = false;
            
            _connectionCreator.StopConnecting();

        }
    }
}
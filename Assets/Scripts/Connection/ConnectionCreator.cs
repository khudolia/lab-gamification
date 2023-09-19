using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ConnectionCreator : MonoBehaviour
{
    private bool isRightClicking = false;

    public GameObject cursorPointer;

    private GameObject _initialObject;
    private GameObject _targetObject;

    private FindTargetConnection _findTargetConnection;

    private void Start()
    {
        _findTargetConnection = GetComponent<FindTargetConnection>();
    }

    public void StartConnecting(GameObject initialObject)
    {
        SetStartConnection(initialObject);
        cursorPointer.SetActive(true);

        CreateConnection(cursorPointer);
    }

    public void StopConnecting()
    {
        RemoveConnection(cursorPointer);
        _findTargetConnection.FindObject();
    }

    public void NoConnectionFound()
    {
        _initialObject = null;
        _targetObject = null;
        cursorPointer.SetActive(false);
    }

    public void SetStartConnection(GameObject startObject)
    {
        _initialObject = startObject;
    }

    public void SetTargetConnection(GameObject targetObject)
    {
        if (_initialObject.name == targetObject.name || IsConnectionAlreadyExists(targetObject))
        {
            NoConnectionFound();
            return;
        }

        bool initialConnectionsBad = IsHasConnections(_initialObject, _initialObject.name is "Start" or "End" ? 0 : 2);
        bool targetConnectionsBad = IsHasConnections(targetObject, targetObject.name is "Start" or "End" ? 0 : 2);
        if (initialConnectionsBad || targetConnectionsBad)
        {
            NoConnectionFound();
            return;
        }

        _targetObject = targetObject;

        cursorPointer.SetActive(false);
        CreateConnection(_targetObject);
    }

    private void CreateConnection(GameObject target)
    {
        // var manager = GetComponent<ConnectionManager>();

        var firstPoint = _initialObject.GetComponent<RectTransform>();
        var secondPoint = target.GetComponent<RectTransform>();
        var connection = ConnectionManager.CreateConnection(firstPoint, secondPoint);

        var connection1 = connection.points[0];
        var connection2 = connection.points[1];
        connection1.direction = ObjectDirectionCalculation.CalculatePosition(secondPoint, firstPoint);
        connection2.direction = ObjectDirectionCalculation.CalculatePosition(firstPoint, secondPoint);

        connection1.weight = .1f;
        connection2.weight = .1f;
    }

    private void RemoveConnection(GameObject target)
    {
        // var manager = GetComponent<ConnectionManager>();

        ConnectionManager.RemoveConnection(ConnectionManager.FindConnection(
            _initialObject.GetComponent<RectTransform>(),
            target.GetComponent<RectTransform>()));
    }

    private bool IsConnectionAlreadyExists(GameObject target)
    {
        return ConnectionManager.FindConnection(
            _initialObject.GetComponent<RectTransform>(),
            target.GetComponent<RectTransform>()) != null;
    }

    private bool IsHasConnections(GameObject gameObject, int numberOfConnections)
    {
        return ConnectionManager.FindConnections(
            gameObject.GetComponent<RectTransform>()).Count > numberOfConnections;
    }
}
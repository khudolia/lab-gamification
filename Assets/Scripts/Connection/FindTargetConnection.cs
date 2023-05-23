using System;
using System.Collections.Generic;
using UnityEngine;

public class FindTargetConnection : MonoBehaviour
{
    private ConnectionCreator _connectionCreator;

    private List<RectTransform> targetRects = new List<RectTransform>();

    private void Start()
    {
        _connectionCreator = GetComponent<ConnectionCreator>();
    }

    public void FindObject()
    {
        targetRects.Clear();
        GameObject[] graphNodes = GameObject.FindGameObjectsWithTag("Node");

        foreach (GameObject node in graphNodes)
        {
            targetRects.Add(node.GetComponent<RectTransform>());
        }

        CheckIntersection();
    }

    private void CheckIntersection()
    {
        // Iterate through all target objects
        foreach (RectTransform targetRect in targetRects)
        {
            var r = _connectionCreator.cursorPointer.GetComponent<RectTransform>();
            bool intersecting = RectTransformUtils.AreRectsIntersecting(r, targetRect);

            if (intersecting)
            {
                _connectionCreator.SetTargetConnection(targetRect.gameObject);
                return; 
            }
        }

        _connectionCreator.NoConnectionFound();
    }
}
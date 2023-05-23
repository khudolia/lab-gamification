using System;
using System.Collections.Generic;
using UnityEngine;

public class LineDirectionUpdater : MonoBehaviour
{
    private void Update()
    {
        List<Connection> connections = ConnectionManager.FindConnections(GetComponent<RectTransform>());

        if (connections == null) return;
        
        foreach (var connection in connections)
        {
            var firstPoint = connection.target[0];
            var secondPoint = connection.target[1];

            var connection1 = connection.points[0];
            var connection2 = connection.points[1];
            connection1.direction = ObjectDirectionCalculation.CalculatePosition(secondPoint,firstPoint);
            connection2.direction = ObjectDirectionCalculation.CalculatePosition(firstPoint, secondPoint);

            //connection.GetComponent<LineRenderer>().startWidth = .02f;
            //connection.GetComponent<LineRenderer>().endWidth = .02f;
        }
    }
}
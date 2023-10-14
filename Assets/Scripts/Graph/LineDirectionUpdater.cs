using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineDirectionUpdater : MonoBehaviour
{
    public bool isEnable = true;

    private static List<ObjectPosition> takenPos = new ();
    private void Update()
    {
        if (!isEnable) return;

        List<Connection> connections = ConnectionManager.FindConnections(GetComponent<RectTransform>());

        if (connections == null) return;

        takenPos.Clear();
        foreach (var connection in connections)
        {
            var connection1 = connection.points[0];
            var connection2 = connection.points[1];
            
            UpdateConnection(connection1, connection2, connection.target[0], connection.target[1]);
            //connection.GetComponent<LineRenderer>().startWidth = .02f;
            //connection.GetComponent<LineRenderer>().endWidth = .02f;
        }
    }

    static public void UpdateConnection(ConnectionPoint c1, ConnectionPoint c2,RectTransform p1, RectTransform p2)
    {
        c1.direction = ObjectDirectionCalculation.CalculatePosition(p2, p1, new[]
        {
            ObjectPosition.Left
        }.Concat(takenPos.ToArray()).ToArray());
        
        takenPos.Add(c1.direction);
        c2.direction = ObjectDirectionCalculation.CalculatePosition(p1, p2, new[]
        {
            ObjectPosition.Right
        }.Concat(takenPos.ToArray()).ToArray());
        
        takenPos.Add(c2.direction);
    }
}
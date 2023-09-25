using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammingNodeCollector : MonoBehaviour
{
    public TrafficLightController trafficLightController;

    public bool isRunning = false;

    private List<String> errors = new List<String>();

    public List<String> CreateSequence()
    {
        errors.Clear();

        // Get all child objects of the parent
        //GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");
        isRunning = true;

        trafficLightController.TurnOnTrafficLight(State.None);
        List<RectTransform> sortedObjects = SortConnections();

        if (sortedObjects.Count == 0)
            errors.Add("No connections");

        if (errors.Count > 0)
            return errors;

        StartCoroutine(RunCode(sortedObjects));

        return errors;
    }

    public void StopSequence()
    {
        isRunning = false;
    }

    private List<RectTransform> SortConnections()
    {
        List<Connection> connections = ConnectionManager.GetConnections();
        List<RectTransform> sortedObjects = new List<RectTransform>();

        sortedObjects.Add(GameObject.Find("StartNode").GetComponent<RectTransform>());

        foreach (Connection connection in connections)
        {
            RectTransform lastObject = sortedObjects[^1];
            List<Connection> newConnections = ConnectionManager.FindConnections(lastObject);

            if (sortedObjects.Count == 1 && newConnections.Count == 0)
                errors.Add("No nodes found");
            if (sortedObjects.Count == 2 && newConnections.Count == 1)
                errors.Add("There should be more than 1 Node");

            foreach (Connection newConnection in newConnections)
            {
                if (newConnection.target[0] == lastObject)
                {
                    RectTransform foundObject = newConnection.target[1];

                    // if (!CheckIfObjectIsInside(sortedObjects, foundObject.name))
                    if (sortedObjects.Count < 1000)
                        sortedObjects.Add(foundObject);
                }
            }
        }

        // for (var i = 0; i < sortedObjects.Count; i++)
        // {
        //     print(i + " " + sortedObjects[i].name);
        // }

        return sortedObjects;
    }

    private RectTransform getPaar(string targetName, RectTransform[] objects)
    {
        foreach (RectTransform o in objects)
        {
            if (o.name == targetName)
            {
                continue;
            }

            return o.GetComponent<RectTransform>();
        }

        return null;
    }

    IEnumerator RunCode(List<RectTransform> nodes)
    {
        // while (isRunning)
        // {
        // Iterate through each child transform
        foreach (RectTransform node in nodes)
        {
            // Check if the child object has a ProgrammingNodeController component
            ProgrammingNodeController nodeController = node.GetComponent<ProgrammingNodeController>();
            if (nodeController != null)
            {
                trafficLightController.currentState = nodeController.model.state;
                print(nodeController.model.state);
                yield return new WaitForSeconds(nodeController.model.length);
            }
        }
        // }
    }

    private bool CheckIfObjectIsInside(List<RectTransform> array, string objectName)
    {
        foreach (RectTransform rectTransform in array)
        {
            if (rectTransform.name == objectName)
            {
                return true;
            }
        }

        return false;
    }
}
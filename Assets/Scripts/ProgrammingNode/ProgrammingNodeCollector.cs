using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProgrammingNodeCollector : MonoBehaviour
{
    public TrafficLightController trafficLightController;

    private List<String> errors = new();

    private Coroutine runningCode;
    private List<RectTransform> sortedObjects = new List<RectTransform>();

    private void Start()
    {
        trafficLightController.currentState = State.None;
    }

    public List<String> CreateSequence()
    {
        errors.Clear();
        sortedObjects.Clear();

        // Get all child objects of the parent
        //GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");

        trafficLightController.TurnOnTrafficLight(State.None);
        sortedObjects = SortConnections();

        if (sortedObjects.Count == 0)
            errors.Add("No connections");

        if (errors.Count > 0)
            return errors;
        
        return errors;
    }
    
    public void RunCode()
    { 
        runningCode = StartCoroutine(RunCode(sortedObjects));
    }

    public void StopSequence()
    {
        if (runningCode == null) return;
        
        StopCoroutine(runningCode);
        trafficLightController.currentState = State.None;
    }

    private List<RectTransform> SortConnections()
    {
        List<Connection> connections = ConnectionManager.GetConnections();
        List<RectTransform> sortedObjects = new List<RectTransform>();

        bool isEnd = false;
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

                    bool isContains = sortedObjects.Contains(foundObject);
                    
                    if (!isEnd)
                        sortedObjects.Add(foundObject);

                    if (isContains)
                        isEnd = true;
                }
            }
        }

        return sortedObjects;
    }

    IEnumerator RunCode(List<RectTransform> nodes)
    {
        foreach (RectTransform node in nodes)
        {
            // Check if the child object has a ProgrammingNodeController component
            ProgrammingNodeController nodeController = node.GetComponent<ProgrammingNodeController>();
            if (nodeController != null)
            {
                trafficLightController.currentState = nodeController.model.state;
                yield return new WaitForSeconds(nodeController.model.length);
            }
        }
        
        //// duplicates
        List<RectTransform> duplicates = nodes.GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .Select(x => x.Key).ToList();

        if (duplicates.Count != 0)
        {
            nodes.RemoveRange(0, nodes.IndexOf(duplicates.First()) + 1);
            while (true)
            {
                foreach (RectTransform node in nodes)
                {
                    // Check if the child object has a ProgrammingNodeController component
                    ProgrammingNodeController nodeController = node.GetComponent<ProgrammingNodeController>();
                    if (nodeController != null)
                    {
                        trafficLightController.currentState = nodeController.model.state;
                        yield return new WaitForSeconds(nodeController.model.length);
                    }
                }
            }
        }

        //// 

    }
}
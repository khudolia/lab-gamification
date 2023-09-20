using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSequenceController : MonoBehaviour
{
    public TrafficLightController trafficLightController;
    public ProgrammingNodeCollector programmingNodeCollector;

    public GameObject startButton;
    public GameObject restartButton;

    public bool isRunning = false;
    private void Start()
    {
        startButton.SetActive(true);
        restartButton.SetActive(false);
    }

    private void Update()
    {
        List<Connection> connections = ConnectionManager.FindConnections(GetComponent<RectTransform>());

        if (connections == null) return;
        
        foreach (var connection in connections)
        {
        }
    }

    public void OnStart()
    {
        GetComponent<SmoothPlaneDistance>().HidePlane();

        programmingNodeCollector.CreateSequence();
        
        restartButton.SetActive(true);
        startButton.SetActive(false);
    }

    public void OnRestart()
    {
        GetComponent<SmoothPlaneDistance>().ShowPlane();

      //  StopCoroutine(ControlTrafficLight());
        programmingNodeCollector.StopSequence();

        
        restartButton.SetActive(false);
        startButton.SetActive(true);
    }
}

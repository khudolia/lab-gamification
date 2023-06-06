using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSequenceController : MonoBehaviour
{
    public TrafficLightController trafficLightController;

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
    
    private IEnumerator ControlTrafficLight()
    {
        while (isRunning)
        {
            trafficLightController.currentState = State.Red;
            yield return new WaitForSeconds(1.2f);
            trafficLightController.currentState = State.RedAndYellow;
            yield return new WaitForSeconds(1.2f);
            trafficLightController.currentState = State.Green;
            yield return new WaitForSeconds(2);
            
            
            trafficLightController.currentState = State.GreenAndYellow;
            yield return new WaitForSeconds(.7f);
            trafficLightController.currentState = State.Green;
            yield return new WaitForSeconds(.7f);
            trafficLightController.currentState = State.GreenAndYellow;
            yield return new WaitForSeconds(.7f);
            trafficLightController.currentState = State.Green;
            yield return new WaitForSeconds(.7f);
            trafficLightController.currentState = State.GreenAndYellow;
            yield return new WaitForSeconds(1f);
            trafficLightController.currentState = State.Red;
            yield return new WaitForSeconds(1);
        }
    }

    public void OnStart()
    {
        GetComponent<SmoothPlaneDistance>().HidePlane();

        isRunning = true;
        StartCoroutine(ControlTrafficLight());
        
        restartButton.SetActive(true);
        startButton.SetActive(false);
    }

    public void OnRestart()
    {
        GetComponent<SmoothPlaneDistance>().ShowPlane();

        isRunning = false;
        StopCoroutine(ControlTrafficLight());
        
        restartButton.SetActive(false);
        startButton.SetActive(true);
    }
}

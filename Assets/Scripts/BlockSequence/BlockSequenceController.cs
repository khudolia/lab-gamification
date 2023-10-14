using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSequenceController : MonoBehaviour
{
    public ProgrammingNodeCollector programmingNodeCollector;
    
    public ErrorController errorController;
    
    public GameObject startButton;
    public GameObject restartButton;
    public GameObject deleteButton;

    public bool isRunning = false;
    private void Start()
    {
        startButton.SetActive(true);
        restartButton.SetActive(false);
        deleteButton.SetActive(true);
        errorController.Disable();
    }
    
    public void OnStart()
    {

        var errors = programmingNodeCollector.CreateSequence();

        if (errors.Count > 0)
        {
            errorController.Enable();
            errorController.ShowErrors(errors);
        }
        if (errors.Count == 0)
        {
            GetComponent<SmoothPlaneDistance>().HidePlane();

            restartButton.SetActive(true);
            startButton.SetActive(false);
            deleteButton.SetActive(false);
            errorController.Disable();
        }
    }

    public void OnRestart()
    {
        GetComponent<SmoothPlaneDistance>().ShowPlane();

      //  StopCoroutine(ControlTrafficLight());
        programmingNodeCollector.StopSequence();

        
        restartButton.SetActive(false);
        startButton.SetActive(true);
        deleteButton.SetActive(true);
    }
}

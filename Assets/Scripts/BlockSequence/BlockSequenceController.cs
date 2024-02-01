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
    
    public bool OnStart()
    {
        var errors = programmingNodeCollector.CreateSequence();

        if (errors.Count > 0)
        {
            errorController.Enable();
            errorController.ShowErrors(errors);

            return false;
        }
        if (errors.Count == 0)
        {
            //GetComponent<SmoothPlaneDistance>().HidePlane();

            restartButton.SetActive(true);
            startButton.SetActive(false);
            deleteButton.SetActive(false);
            errorController.Disable();
            
            return true;
        }

        return true;
    }

    public void RunCode()
    {
        programmingNodeCollector.RunCode();
    }

    public void OnRestart()
    {
        //  StopCoroutine(ControlTrafficLight());
        programmingNodeCollector.StopSequence();

        
        restartButton.SetActive(false);
        startButton.SetActive(true);
        deleteButton.SetActive(true);
    }
}

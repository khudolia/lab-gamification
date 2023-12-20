using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTrafficLight : MonoBehaviour
{
    private ACTrafficLight _acTrafficLight;
    private BlockSequenceController _blockSequenceController;

    private void Start()
    {
        _acTrafficLight = GetComponent<ACTrafficLight>();
        _blockSequenceController = GetComponent<BlockSequenceController>();
        
        StartCoroutine(DelayAndReStart(0.2f));

    }

    private IEnumerator DelayAndReStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        _acTrafficLight.MoveInAnimation();
        _blockSequenceController.OnRestart();
        
        yield return null;

    }
    
    private IEnumerator DelayAndStart()
    {
        if (_blockSequenceController.OnStart())
        {
            _acTrafficLight.MoveOutAnimation();
            yield return new WaitForSeconds(2.0f);
            _blockSequenceController.RunCode();
        }
    }

    public void OnStart()
    {
        StartCoroutine(DelayAndStart());
    }

    public void OnRestart()
    {
        StartCoroutine(DelayAndReStart(.0f));
    }

}

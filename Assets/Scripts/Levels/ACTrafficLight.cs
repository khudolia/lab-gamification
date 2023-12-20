using System.Collections;
using UnityEngine;

public class ACTrafficLight : MonoBehaviour
{
    public Animator aCamera;
    public Animator aElectricalBox;
    private bool isPlaying = false;
    
    public void MoveInAnimation()
    {
        aCamera.SetBool("startProgramming", true);
        aElectricalBox.SetBool("startProgramming", true);
    }

    public void MoveOutAnimation()
    {
        StartCoroutine(MoveOutDelay());
    }
    
    private IEnumerator MoveOutDelay()
    {
        aCamera.SetBool("startProgramming", false);
        yield return new WaitForSeconds(1.0f);
        aElectricalBox.SetBool("startProgramming", false);
    }
}
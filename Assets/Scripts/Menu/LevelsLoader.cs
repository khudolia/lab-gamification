using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsLoader : MonoBehaviour
{
    public void LoadTrafficLight()
    {
        SceneManager.LoadScene("TrafficLightScene", LoadSceneMode.Single);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}

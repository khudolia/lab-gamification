using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    public GameObject pausePanel;

    private bool _pausePanelState = false;
    
    void Start()
    {
        pausePanel.SetActive(_pausePanelState);
    }

    public void ChangePauseState()
    {
        _pausePanelState = !_pausePanelState;

        Time.timeScale = _pausePanelState ? 0 : 1;
        pausePanel.SetActive(_pausePanelState);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

    }
}

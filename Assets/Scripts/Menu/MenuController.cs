using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject creditsPanel;
    public GameObject levelsPanel;

    private bool _creditsPanelState = false;
    private bool _levelsPanelPanelState = false;
    
    void Start()
    {
        creditsPanel.SetActive(_creditsPanelState);
        levelsPanel.SetActive(_levelsPanelPanelState);
        mainPanel.SetActive(true);
    }

    public void ChangeCreditsState()
    {
        _creditsPanelState = !_creditsPanelState;
        creditsPanel.SetActive(_creditsPanelState);
        
        mainPanel.SetActive(!_creditsPanelState);
    }

    public void ChangeLevelsState()
    {
        _levelsPanelPanelState = !_levelsPanelPanelState;
        levelsPanel.SetActive(_levelsPanelPanelState);
        
        mainPanel.SetActive(!_levelsPanelPanelState);

    }
}

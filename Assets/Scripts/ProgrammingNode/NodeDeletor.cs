using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeDeletor : MonoBehaviour
{
    private Outline _outline;
    public ConnectionDestroyer connectionDestroyer;

    private bool _isSelected = false;
    private bool _isSelectedPrevious = false;

    void Start()
    {
        _outline = GetComponent<Outline>();
        connectionDestroyer = FindObjectsOfType<ConnectionDestroyer>()[0];
        UpdateOutline();
    }

    // Update is called once per frame
    void Update()
    {
        _isSelected = connectionDestroyer.selectedObject == gameObject;
        
        if (_isSelected != _isSelectedPrevious)
        {
            UpdateOutline();
            
            _isSelectedPrevious = _isSelected;
        }
    }

    public void OnPress()
    {
        if (!_isSelected)
            connectionDestroyer.Select(gameObject);
        else
            connectionDestroyer.ClearSelection();


        UpdateOutline();
    }

    private void UpdateOutline()
    {
        _outline.effectDistance = new Vector2(_isSelected ? 6 : 0, _isSelected ? 6 : 0);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorController : MonoBehaviour
{
    public Transform content;

    public GameObject errorPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
    
    public void ShowErrors(List<String> errors)
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
        
        for (int i = 0; i < errors.Count; i++)
        {
            var createdObject = Instantiate(errorPrefab);
            createdObject.transform.SetParent(content, false);

            createdObject.GetComponentInChildren<TMP_Text>().SetText(errors[i]);
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class NewItemController : MonoBehaviour
{
    private Vector3 startLocation;
    public GameObject startObject;
    
    public float distanceToStart;
    
    public GameObject prefab;
    public GameObject prefabNode;
    public GameObject currentObject;

    private int countOfSpawnedObjects = 0;
    private void Start()
    {
        //startLocation = transform.position;
        SpawnNewItem();
    }

    private void Update()
    {
        if (currentObject.GetComponent<Drag>().isDragging)
            return;
        
        if (Vector3.Distance(transform.position, currentObject.transform.position) > distanceToStart)
        {
            GameObject newNode = Instantiate(prefabNode, currentObject.transform.position, currentObject.transform.rotation, currentObject.transform.parent);
            newNode.name = "ProgrammingNode" + countOfSpawnedObjects;
            
            if(countOfSpawnedObjects == 1)
                startObject.GetComponent<StartConnectionCreator>().ConnectToFirst();
            
            Destroy(currentObject);
            SpawnNewItem();
        }
        else
        {
            currentObject.transform.position = transform.position;
        }
    }

    private void SpawnNewItem()
    {
        currentObject = Instantiate(prefab, transform.position, transform.rotation, transform.parent);
        countOfSpawnedObjects++;
    }
}
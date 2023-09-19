using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConnectionCreator : MonoBehaviour
{
    private ConnectionCreator _connectionCreator;

    // Start is called before the first frame update
    void Start()
    {
        var connection = GameObject.Find("ConnectionManager");
        _connectionCreator = connection.GetComponent<ConnectionCreator>();
    }

    public void ConnectToFirst()
    {
        ProgrammingNodeController[] scriptComponents = FindObjectsOfType<ProgrammingNodeController>();

        if (scriptComponents.Length > 0)
        {
            MonoBehaviour closestObjectWithScript = null;
            float closestDistance = float.MaxValue;

            foreach (MonoBehaviour scriptComponent in scriptComponents)
            {
                float distance = Vector3.Distance(transform.position, scriptComponent.transform.position);

                if (distance < closestDistance)
                {
                    closestObjectWithScript = scriptComponent;
                    closestDistance = distance;
                }
            }

            if (closestObjectWithScript != null)
            {
                _connectionCreator.SetStartConnection(gameObject);
                _connectionCreator.SetTargetConnection(closestObjectWithScript.gameObject);

            }
        }
    }
}

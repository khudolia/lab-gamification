using System;
using UnityEngine;

public class ConnectionSelecter : MonoBehaviour
{
    public ConnectionDestroyer connectionDestroyer;

    private LineRenderer lineRenderer;
    public float closeDistance = 20f;

    public Color selectedColor;
    public Color highlightColor;
    public Color initialColor;
    public bool isSelected = false;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        initialColor = lineRenderer.startColor;
    }

    private void Update()
    {
        bool isSelected = connectionDestroyer.selectedObject == gameObject;
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the LineRenderer's positions to screen coordinates
        Vector3[] screenPositions = new Vector3[lineRenderer.positionCount];
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            screenPositions[i] = Camera.main.WorldToScreenPoint(lineRenderer.GetPosition(i));
        }

        bool isOnLine = false;
        // Check if the mouse position is close to any of the LineRenderer's positions
        for (int i = 0; i < screenPositions.Length; i++)
        {
            float distance = Vector3.Distance(screenPositions[i], mousePosition);

            if (distance < closeDistance)
            {
                isOnLine = true;
                break;
            }
        }

        // Calculate the distance between the mouse position and the LineRenderer's position in screen space

        // If the distance is smaller than the closeDistance, change the LineRenderer's color
        if (isOnLine)
        {
            lineRenderer.startColor = isSelected ? selectedColor : highlightColor;
            lineRenderer.endColor = isSelected ? selectedColor : highlightColor;

            if (Input.GetMouseButtonDown(0))
            {
                if (isSelected)
                    connectionDestroyer.ClearSelection();
                else
                    connectionDestroyer.Select(gameObject);
            }
        }
        else
        {
            lineRenderer.startColor = isSelected ? selectedColor : initialColor;
            lineRenderer.endColor = isSelected ? selectedColor : initialColor;

            if (Input.GetMouseButtonDown(0) && isSelected)
                connectionDestroyer.ClearSelection();
        }

        if (isSelected)
        {
            if (Input.GetKeyDown(KeyCode.Delete))
                DestroyObject();

            // Special case for Apple laptops, where there is no "DEL" button
            if (Input.GetKey(KeyCode.LeftCommand) && Input.GetKey(KeyCode.Backspace))
                DestroyObject();

            if (Input.GetKeyDown(KeyCode.Escape))
                connectionDestroyer.ClearSelection();
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
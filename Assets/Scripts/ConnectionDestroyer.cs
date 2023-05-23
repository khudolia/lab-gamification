using System;
using UnityEngine;

public class ConnectionDestroyer : MonoBehaviour
{
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
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the LineRenderer's positions to screen coordinates
        Vector3[] screenPositions = new Vector3[lineRenderer.positionCount];
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            screenPositions[i] = Camera.main.WorldToScreenPoint(lineRenderer.GetPosition(i));
        }

        // Check if the mouse position is close to any of the LineRenderer's positions
        for (int i = 0; i < screenPositions.Length; i++)
        {
            // Calculate the distance between the mouse position and the LineRenderer's position in screen space
            float distance = Vector3.Distance(screenPositions[i], mousePosition);

            // If the distance is smaller than the closeDistance, change the LineRenderer's color
            if (distance < closeDistance)
            {
                if (!isSelected)
                {
                    lineRenderer.startColor = highlightColor;
                    lineRenderer.endColor = highlightColor;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    isSelected = !isSelected;
                }

                return; // Exit the method if a close position is found
            }
            else
            {
                if (isSelected)
                {
                    lineRenderer.startColor = selectedColor;
                    lineRenderer.endColor = selectedColor;
                }
                else
                {
                    lineRenderer.startColor = initialColor;
                    lineRenderer.endColor = initialColor;
                }
            }
        }

        // If no close position is found, reset the LineRenderer's color
        if (isSelected)
        {
             if(Input.GetKeyDown(KeyCode.Delete))
                 DestroyObject();
             
             if(Input.GetKey(KeyCode.LeftCommand) && Input.GetKey(KeyCode.Backspace))
                 DestroyObject();
             
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isSelected = false;
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
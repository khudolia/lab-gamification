using UnityEngine;

public class LineRendererWithArrow : MonoBehaviour
{
    public GameObject arrowPrefab;

    private LineRenderer lineRenderer;
    private Transform arrow;

    private void Start()
    {
        arrow = Instantiate(arrowPrefab, transform).transform;

        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        DrawLine(lineRenderer.GetPosition(0), lineRenderer.GetPosition(lineRenderer.positionCount - 1));
    }

    public void DrawLine(Vector3 startPoint, Vector3 endPoint)
    {
        
        arrow.position = endPoint;
        Quaternion lookRotation = Quaternion.LookRotation(endPoint - startPoint, Vector3.up) * Quaternion.Euler(0, 90, 0);
        arrow.localRotation = Quaternion.Euler(-90, 90, lookRotation.z);
    }
}
using UnityEngine;
using System.Collections;

public class SmoothPlaneDistance : MonoBehaviour
{
    public float startValue = 1f;
    public float endValue = 12f;
    public float duration = 1f;

    private Canvas canvas;

    private void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
    public void HidePlane()
    {
        startValue = 1;
        endValue = 12;
        StartCoroutine(ChangePlaneDistanceSmoothly(false));
    }

    public void ShowPlane()
    {
        startValue = 12;
        endValue = 1;
        StartCoroutine(ChangePlaneDistanceSmoothly(true));
    }

    private IEnumerator ChangePlaneDistanceSmoothly(bool isAppearing)
    {
        if(isAppearing) canvas.gameObject.SetActive(true);
        float elapsedTime = 0f;
        float t = 0f;

        while (t < 1f)
        {
            elapsedTime += Time.deltaTime;
            t = Mathf.Clamp01(elapsedTime / duration);

            // Interpolate the planeDistance value smoothly
            float planeDistance = Mathf.Lerp(startValue, endValue, t);

            // Apply the new planeDistance value to the Canvas
            canvas.planeDistance = planeDistance;

            yield return null;
        }

        // Ensure the final planeDistance value is exactly the endValue
        canvas.planeDistance = endValue;
        if(!isAppearing) canvas.gameObject.SetActive(false);
    }
}
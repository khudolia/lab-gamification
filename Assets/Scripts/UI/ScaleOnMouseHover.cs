using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleOnMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Vector3 originalScale;
    private Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1.2f);
    private float scaleSpeed = 10.0f; // Adjust the speed as desired

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Start a coroutine to smoothly scale up on mouse hover
        StartCoroutine(ScaleOverTime(hoverScale));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Start a coroutine to smoothly scale back to original size on mouse exit
        StartCoroutine(ScaleOverTime(originalScale));
    }

    private IEnumerator ScaleOverTime(Vector3 targetScale)
    {
        float elapsedTime = 0f;
        Vector3 startingScale = rectTransform.localScale;

        while (elapsedTime < 1f)
        {
            rectTransform.localScale = Vector3.Lerp(startingScale, targetScale, elapsedTime);
            elapsedTime += Time.deltaTime * scaleSpeed;
            yield return null;
        }

        rectTransform.localScale = targetScale;
    }
}
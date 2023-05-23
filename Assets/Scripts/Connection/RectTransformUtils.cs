using UnityEngine;

public static class RectTransformUtils
{
    public static bool AreRectsIntersecting(RectTransform rectTransformA, RectTransform rectTransformB)
    {
        // Get the rect boundaries of the RectTransforms
        Rect rectA = rectTransformA.rect;
        Rect rectB = rectTransformB.rect;

        // Convert the RectTransform positions to world space
        Vector3[] cornersA = new Vector3[4];
        Vector3[] cornersB = new Vector3[4];
        rectTransformA.GetWorldCorners(cornersA);
        rectTransformB.GetWorldCorners(cornersB);

        // Check for intersection by comparing the rect boundaries
        if (rectA.xMax < rectB.xMin || rectA.xMin > rectB.xMax ||
            rectA.yMax < rectB.yMin || rectA.yMin > rectB.yMax)
        {
            return false;
        }

        // Check for intersection by comparing the world space positions
        for (int i = 0; i < 4; i++)
        {
            if (IsPointInsideRect(cornersA[i], cornersB) || IsPointInsideRect(cornersB[i], cornersA))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsPointInsideRect(Vector3 point, Vector3[] rectCorners)
    {
        Vector3 bottomLeft = rectCorners[0];
        Vector3 topRight = rectCorners[2];

        return point.x >= bottomLeft.x && point.x <= topRight.x && point.y >= bottomLeft.y && point.y <= topRight.y;
    }
}
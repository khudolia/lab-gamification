using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum ObjectPosition {
    Top,
    Right,
    Bottom,
    Left
}
public static class ObjectDirectionCalculation
{
    public static ObjectPosition CalculatePosition(RectTransform targetObject, RectTransform referenceObject, ObjectPosition[] exceptions)
    {
        Vector3 targetPosition = targetObject.position;
        Vector3 referencePosition = referenceObject.position;

        // Calculate the local positions of the target and reference objects
        Vector3 localTargetPosition = referenceObject.InverseTransformPoint(targetPosition);

        // Calculate the half width and height of the reference object
        float referenceHalfWidth = referenceObject.rect.width * 0.5f;
        float referenceHalfHeight = referenceObject.rect.height * 0.5f;

        // Compare the local positions to determine the position
        if (localTargetPosition.x > referenceHalfWidth && !exceptions.Contains(ObjectPosition.Right))
        {
            return ObjectPosition.Right;
        }
        else if (localTargetPosition.x < -referenceHalfWidth && !exceptions.Contains(ObjectPosition.Left))
        {
            return ObjectPosition.Left;
        }
        else if (localTargetPosition.y > referenceHalfHeight && !exceptions.Contains(ObjectPosition.Top))
        {
            return ObjectPosition.Top;
        }
        else
        {
            return ObjectPosition.Bottom;
        }
    }
}

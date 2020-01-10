using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static Vector3 Snap(this Vector3 vector, float gridSize = 1f)
    {
        return new Vector3(
            x: gridSize * Mathf.Round(vector.x / gridSize),
            y: gridSize * Mathf.Round(vector.y / gridSize),
            z: gridSize * Mathf.Round(vector.z / gridSize)
            );
    }

    public static void Reset(this Transform transform)
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
}

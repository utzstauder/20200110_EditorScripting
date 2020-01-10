using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LineOfSight))]
public class LineOfSightEditor : Editor
{
    private void OnSceneGUI()
    {
        LineOfSight lineOfSight = (LineOfSight) target;

        Handles.color = lineOfSight.debugColor;

        Vector3 fromVector = Quaternion.AngleAxis(
            angle: -lineOfSight.viewAngle / 2,
            axis: lineOfSight.transform.up
            ) * lineOfSight.transform.forward;

        Handles.DrawSolidArc(
            center: lineOfSight.transform.position,
            normal: lineOfSight.transform.up,
            from: fromVector,
            angle: lineOfSight.viewAngle,
            radius: lineOfSight.viewDistance
            );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class SceneViewEditor : Editor
{
    static Vector3 handlePosition;

    static SceneViewEditor()
    {
        SceneView.duringSceneGui += SceneView_duringSceneGui;
    }

    private static void SceneView_duringSceneGui(SceneView sceneView)
    {
        // Debug.Log("duringSceneGui");

        //Handles.BeginGUI();
        //{
        //    GUILayout.BeginHorizontal();
        //    {
        //        for (int i = 0; i < 10; i++)
        //        {
        //            GUILayout.Button("Button");
        //        }
        //    }
        //    GUILayout.EndHorizontal();
        //}
        //Handles.EndGUI();

        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            handlePosition = hitInfo.point;
        }

        Handles.DrawWireCube(
            center: handlePosition,
            size: Vector3.one
            );

        SceneView.RepaintAll();
    }
}

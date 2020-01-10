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
        // override default controls
        int controlID = GUIUtility.GetControlID(FocusType.Passive);
        HandleUtility.AddDefaultControl(controlID);

        UpdateHandlePosition();

        if (Event.current.type == EventType.MouseDown
            && Event.current.button == 0)
        {
            PlaceObject(handlePosition);
        }

        DrawHandle();

        SceneView.RepaintAll();
    }

    private static void PlaceObject(Vector3 position)
    {
        GameObject cube;
        Object cubePrefab;

        // cubePrefab = Resources.Load("Prefabs/Cube");

        cubePrefab = AssetDatabase.LoadAssetAtPath<Object>("Assets/Resources/Prefabs/Cube.prefab");

        cube = (GameObject) PrefabUtility.InstantiatePrefab(cubePrefab);
        cube.transform.position = position;

        Undo.RegisterCreatedObjectUndo(cube, "Placed Cube object");
    }

    private static void DrawHandle()
    {
        Handles.color = Color.green;

        Handles.DrawWireCube(
                    center: handlePosition,
                    size: Vector3.one
                    );
    }

    private static void UpdateHandlePosition()
    {
        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 offset = Vector3.zero;

            if (hitInfo.transform.gameObject.CompareTag("Grid") == false)
            {
                offset = hitInfo.normal;
            }

            handlePosition.x = Mathf.Round(hitInfo.point.x - hitInfo.normal.x * 0.001f + offset.x);
            handlePosition.y = Mathf.Round(hitInfo.point.y - hitInfo.normal.y * 0.001f + offset.y);
            handlePosition.z = Mathf.Round(hitInfo.point.z - hitInfo.normal.z * 0.001f + offset.z);
        }
    }
}

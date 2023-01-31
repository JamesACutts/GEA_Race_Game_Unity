using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CheckpointSpawner : EditorWindow
{
    string objectName = "";
    int objectID = 1;
    int laps = 0;


    GameObject gameController;
    GameObject objectPrefab;
    Transform parent;



    [MenuItem("Tools/Checkpoint Spawner")]
    // Add to the menu bar at the top of the screen
    public static void ShowWindow()
    {
        GetWindow(typeof(CheckpointSpawner));
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn Checkpoint", EditorStyles.boldLabel);
        // creating different fields for all thats needed on my editor
        gameController = EditorGUILayout.ObjectField("Game Controller", gameController, typeof(GameObject), true) as GameObject;

        objectName = EditorGUILayout.TextField("Name", objectName);

        objectID = EditorGUILayout.IntField("Object ID", objectID);

        laps = EditorGUILayout.IntField("Laps", laps);

        objectPrefab = EditorGUILayout.ObjectField("Prefab to Spawn", objectPrefab, typeof(GameObject), true) as GameObject;

        parent = EditorGUILayout.ObjectField("Parent", parent, typeof(Transform), true) as Transform;

        
        // logic for the buttons to call different methods 
        if (GUILayout.Button("Update Laps"))
        {
            gameController.GetComponent<GameController>().EditorUpdate(laps);
        }

        if (GUILayout.Button("Spawn Checkpoint"))
        {
            SpawnObject();
        }

        if (GUILayout.Button("Reset"))
        {
            Reset();
        }
    }
    // the spawn function that will be called 
    private void SpawnObject()
    {
        if (objectName == null)
        {
            Debug.LogError("Error: Please assign an object to be spawned.");
            return;
        }
        if (objectName == string.Empty)
        {
            Debug.LogError("Error: Please enter a name for the object.");
            return;
        }

        Vector3 spawnPos = new Vector3(-11, 2.12f, 17.40f);

        GameObject newObject = Instantiate(objectPrefab, spawnPos, Quaternion.identity, parent);
        newObject.name = objectName + objectID;

        objectID++;

    }
    //the reset function that will be called
    private void Reset()
    {
        objectName = "";
        objectID = 1;
        laps = 0;
        gameController.GetComponent<GameController>().EditorUpdate(laps);
    }
}
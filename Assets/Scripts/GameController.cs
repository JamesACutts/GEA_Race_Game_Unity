using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int laps = 0;
    public int objectID = 0;
    public int checkpointCount = 0;
    public int lapsFinished = 0;

    public void EditorUpdate(int n)
    {
        laps = n;
    }
    public void EditorUpdate1(int j)
    {
        objectID = j;
    }

 /*   public void checkpounts()
    {
        if (objectID == checkpointCount)
        {
            lapsFinished++;
            Debug.Log("Laps++");

        }
        if (lapsFinished == laps)
        {
            Debug.Log("Finished");
        }
    }*/
}

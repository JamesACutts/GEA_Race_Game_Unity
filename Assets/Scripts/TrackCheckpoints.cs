using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrackCheckpoints : MonoBehaviour
{
    public event EventHandler OnPlayerCorrectCP;
    public event EventHandler OnPlayerWrongCP;
    public int checkpointCount = 0;
    public int lapsdone = 0;


    private List<CheckpointSingle> checkpointSingleList;
    private int nextCheckpointSingleIndex;

    private void Start()
    {
        CheckpointSingle nextCheckpointSingle = checkpointSingleList[nextCheckpointSingleIndex];
        nextCheckpointSingle.Show();
    }

    private void Awake()
    {
        // finding the checkpoint container 
        Transform CheckpointsTransform = transform.Find("Checkpoints");
        // going through all the children of the parent 
        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform CheckpointSingleTransform in CheckpointsTransform)
        {
            CheckpointSingle checkpointSingle = CheckpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoints(this);
            checkpointSingleList.Add(checkpointSingle);
        }

        nextCheckpointSingleIndex = 0;
    }

    // checking which checkpoint the player has gone through
    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {

            CheckpointSingle nextCheckpointSingle = checkpointSingleList[(nextCheckpointSingleIndex + 1) % checkpointSingleList.Count];
            nextCheckpointSingle.Show();

            // Correct
            Debug.Log("Correct");
            CheckpointSingle correctCheckpointSignle = checkpointSingleList[nextCheckpointSingleIndex];
            correctCheckpointSignle.Hide();

            nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
            OnPlayerCorrectCP?.Invoke(this, EventArgs.Empty);

            if (nextCheckpointSingleIndex == 1)
            {
                lapsdone++;
                Debug.Log("Lap Finished");
                Debug.Log(lapsdone);
            }
        }
        else
        {
            // Wrong
            Debug.Log("Wrong");
            OnPlayerWrongCP?.Invoke(this, EventArgs.Empty);

            CheckpointSingle correctCheckpointSignle = checkpointSingleList[nextCheckpointSingleIndex];

            correctCheckpointSignle.Show();
        }
    }

}

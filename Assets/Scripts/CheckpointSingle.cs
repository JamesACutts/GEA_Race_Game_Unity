using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckpointSingle : MonoBehaviour
{
    private TrackCheckpoints trackCheckpoints;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        Hide();
    }

    // checking for collidion with the player and the checkpoint
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<WheelController>(out WheelController player))
        {
            trackCheckpoints.PlayerThroughCheckpoint(this);
        }
    }


    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
    // showing and hiding checkpoints 
    public void Show()
    {
        meshRenderer.enabled = true;
    }

    public void Hide()
    {
        meshRenderer.enabled = false;
    }
}

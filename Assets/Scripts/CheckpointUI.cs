using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUI : MonoBehaviour
{
    [SerializeField]
    private TrackCheckpoints trackCheckpoints;

    private void Start()
    {
        trackCheckpoints.OnPlayerCorrectCP += TrackCheckpoints_OnPlayerCorrectCP;
        trackCheckpoints.OnPlayerWrongCP += TrackCheckpoints_OnPlayerWrongCP;

        Hide();
    }

    private void TrackCheckpoints_OnPlayerWrongCP(object sender, EventArgs e)
    {
        Show();
    }

    private void TrackCheckpoints_OnPlayerCorrectCP(object sender, EventArgs e)
    {
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

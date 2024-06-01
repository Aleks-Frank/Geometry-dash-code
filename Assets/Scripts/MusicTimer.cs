using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTimer : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("DisplayTime", 0f, 1f);
    }

    void DisplayTime()
    {
        if (audioSource.isPlaying)
        {
            Debug.Log("Time: " + audioSource.time);
        }
    }
}

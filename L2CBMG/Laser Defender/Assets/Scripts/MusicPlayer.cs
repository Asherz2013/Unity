﻿using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;

    public AudioClip StartClip;
    public AudioClip GameClip;
    public AudioClip EndClip;

    private AudioSource Music;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing!");
        }
        else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            // Obtain the audio source and play the first clip
            Music = GetComponent<AudioSource>();
            Music.clip = StartClip;
            Music.loop = true;
            Music.Play();
        }
    }

    // Upon level loaded lets decide what music to play
    void OnLevelWasLoaded(int level)
    {
        Music.Stop();

        switch(level)
        {
            case 0:
                Music.clip = StartClip;
                break;
            case 1:
                Music.clip = GameClip;
                break;
            case 2:
                Music.clip = EndClip;
                break;
        }

        Music.loop = true;
        Music.Play();
    }
}

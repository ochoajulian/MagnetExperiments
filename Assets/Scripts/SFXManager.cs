﻿using UnityEngine.Audio;
using System;
using UnityEngine;

//Used to easily implement an SFX anywhere in the game
public class SFXManager : MonoBehaviour
{
    public Sound[] sounds;

    // Use this for initialization
    void Awake()
    {


        foreach (Sound s in sounds)
        {
            //Adds an Audio Source component whenever a sound is called
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        //Play("BGM");
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound:" + name + "not found!");
            return;
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound:" + name + "not found!");
            return;
        }
        s.source.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{/*
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.M;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }
    
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Play("MainMenu");

        }
        else
        {
            Play("MainGame");
        }

        
    }
    void Stop()
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        //foreach (var item in collection)
        {

        }
    }
    */
}

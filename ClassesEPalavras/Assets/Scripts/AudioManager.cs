using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance
    {
        get
        {
            if (Instance == null)
            {
                instance = GameObject.FindObjectOfType<AudioManager>();
            }
            return instance;
        }
    }
    
    public Sounds[] sounds;
    
    private static AudioManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loopActive;
            s.source.mute = s.mute;
            s.source.playOnAwake = s.playAwake;
        }
    }

    public void PlaySound(string name)
    {
        if (PlayerPrefs.GetInt("enableSounds") == 1)
        {
            Sounds s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }
    }

    public void PlayMusic(string name)
    {
        if (PlayerPrefs.GetInt("enableMusic") == 1)
        {
            Sounds s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }
    }

    public void StopMusic(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void PauseMusic(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.isPaused = true;
        s.source.Pause();
    }

    public void UnPauseMusic(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.isPaused = false;
        s.source.UnPause();
    }

    public void MuteMusic(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.mute = true;
    }

    public void UnmuteMusic(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.mute = false;
    }

    public bool isMusicPlaying(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        return s.source.isPlaying;
    }

    public bool isMusicPaused(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s.isPaused)
        {
            return true;
        } else { return false; }

    }

}

    


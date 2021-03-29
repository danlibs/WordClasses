using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [HideInInspector]
    public AudioSource source;
    public bool loopActive;
    public bool mute;
    public bool isPaused;
    public bool playAwake;
    
}

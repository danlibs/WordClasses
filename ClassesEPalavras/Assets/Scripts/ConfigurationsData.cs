using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConfigurationsData
{
    public int pointsToSentences;
    public bool enableMusic;
    public bool enableSounds;

    public ConfigurationsData(GameManager configData)
    {
        pointsToSentences = GameManager.pointsToSentences;
        enableMusic = GameManager.isMusicEnabled;
        enableSounds = GameManager.areSoundsEnabled;
    } 
}

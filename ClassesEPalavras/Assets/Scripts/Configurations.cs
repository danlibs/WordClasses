using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Configurations : MonoBehaviour
{
    public InputField inputField;
    public Toggle music;
    public Toggle sounds;

    private void Awake()
    {
        inputField = GetComponentInChildren<InputField>();
        GameObject musicToggle = transform.Find("EnableMusicText").gameObject;
        GameObject soundsToggle = transform.Find("EnableSoundsText").gameObject;
        music = musicToggle.GetComponentInChildren<Toggle>();
        sounds = soundsToggle.GetComponentInChildren<Toggle>();
    }

    private void OnEnable()
    {
        if (SaveSystem.ConfigsPathHasFile())
        {
            GameManager.LoadConfigurations();
            TextOnInput();
            sounds.isOn = GameManager.areSoundsEnabled;
            music.isOn = GameManager.isMusicEnabled;
        }
        else
        {
            inputField.GetComponentInChildren<Text>().text = "500";
            music.isOn = true;
            sounds.isOn = true;
        }

    }

    private void OnDisable()
    {
        
    }

    public void EnableMusic(bool value)
    {
        GameManager.isMusicEnabled = value;
    }

    public void EnableSounds(bool value)
    {
        GameManager.areSoundsEnabled = value;
    }

    public void TextOnInput()
    {
        inputField.GetComponentInChildren<Text>().text = GameManager.pointsToSentences.ToString();
    }
}

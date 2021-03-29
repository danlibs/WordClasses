using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetter : MonoBehaviour
{
    private Button button;
    private AudioManager audioManager;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (tag == "OpenButton")
        {
            button.onClick.AddListener(delegate { PlaySound("ButtonOpen"); });
        }
        if (tag == "CloseButton")
        {
            button.onClick.AddListener(delegate { PlaySound("ButtonClose"); });
        }

    }

    public void PlaySound(string soundName)
    {
        audioManager.PlaySound(soundName);
    }


}

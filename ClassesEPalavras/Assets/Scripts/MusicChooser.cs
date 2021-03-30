using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicChooser : MonoBehaviour
{
    private AudioManager audioManager;
    private bool isMenuMusicPlaying;
    private bool isGameMusicPlaying;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            audioManager.StopMusic("GameMusic");
            audioManager.PlayMusic("MainMenuMusic");
        }

        if (SceneManager.GetActiveScene().name == "Game")
        {
            audioManager.StopMusic("MainMenuMusic");
            audioManager.PlayMusic("GameMusic");
        }

        if (PlayerPrefs.GetInt("enableMusic") == 1)
        {
            isGameMusicPlaying = true;
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("enableMusic") == 0)
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                audioManager.MuteMusic("MainMenuMusic");
            }

            if (SceneManager.GetActiveScene().name == "Game")
            {
                audioManager.MuteMusic("GameMusic");
            }
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                if (audioManager.isMusicPlaying("MainMenuMusic"))
                {
                    audioManager.UnmuteMusic("MainMenuMusic");
                }
                else if (!isMenuMusicPlaying)
                {
                    audioManager.PlayMusic("MainMenuMusic");
                    isMenuMusicPlaying = true;
                }
            }

            if (SceneManager.GetActiveScene().name == "Game")
            {
                if (audioManager.isMusicPlaying("GameMusic"))
                {
                    audioManager.UnmuteMusic("GameMusic");
                }
                else if (!isGameMusicPlaying)
                {
                    audioManager.PlayMusic("GameMusic");
                    isGameMusicPlaying = true;
                }
            }
        }
    }
}

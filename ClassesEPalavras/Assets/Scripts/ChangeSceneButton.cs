using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    private Button mainMenuButton;
    private GameManager gameManager;
    private Scene currentScene;

    private void Awake()
    {
        mainMenuButton = GetComponent<Button>();
        currentScene = SceneManager.GetActiveScene();
    }

    private void Start()
    {
        gameManager = GameManager.FindObjectOfType<GameManager>();
        if (currentScene.name == "Game")
        {
            mainMenuButton.onClick.AddListener(delegate { ChangeScene(0); });
        }
        else if (currentScene.name == "MainMenu")
        {
            mainMenuButton.onClick.AddListener(delegate { ChangeScene(1); });
        }

    }

    private void ChangeScene(int sceneIndex)
    {
        GameDirector.points = 0;
        GameManager.spawnState = GameManager.SpawnState.Word;
        gameManager.ChangeScene(sceneIndex);
    }
}

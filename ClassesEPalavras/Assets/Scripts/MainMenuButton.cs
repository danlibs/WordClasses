using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    private Button mainMenuButton;
    private GameManager gameManager;

    private void Awake()
    {
        mainMenuButton = GetComponent<Button>();
    }

    private void Start()
    {
        gameManager = GameManager.FindObjectOfType<GameManager>();
        mainMenuButton.onClick.AddListener(delegate { ChangeScene(); });
    }

    private void ChangeScene()
    {
        gameManager.ChangeScene(0);
    }
}

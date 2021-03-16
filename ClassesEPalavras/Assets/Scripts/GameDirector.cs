using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirector: MonoBehaviour
{
    public int points;

    [SerializeField]
    private TMP_Text pointsText;
    [SerializeField]
    private TMP_Text timeText;
    [SerializeField]
    private GameObject gameOverBox;
    [SerializeField]
    private GameObject[] spawners;
    [SerializeField]
    private GameObject pauseMenu;

    public float timeRemaining = 30;
    private bool timerIsRunning;
    private bool gameIsOver;
    private GameObject[] boxesOnScene;

    private void Start()
    {
        timerIsRunning = true;
    }

    private void Update()
    {
        if (!gameIsOver)
        {
            EnableSpawners();
            if (timerIsRunning)
            {
                if (timeRemaining >= 0)
                {
                    timeRemaining -= Time.deltaTime;
                    timeText.text = Mathf.FloorToInt(timeRemaining % 60).ToString();
                }
                else
                {
                    timeRemaining = 0;
                    timeText.text = timeRemaining.ToString();
                    Debug.Log("Tempo esgotado!");
                    timerIsRunning = false;
                    GameOver();
                }
            }

        }    
    }

    public void UpdatePoints()
    {
        pointsText.text = points.ToString();
    }

    private void EnableSpawners()
    {
        if (points >= 0 && !spawners[0].GetComponent<WordSpawner>().isActive)
        {
            spawners[0].GetComponent<WordSpawner>().isActive = true;
        }

        if (points >= 10 && !spawners[1].GetComponent<WordSpawner>().isActive)
        {
            spawners[1].GetComponent<WordSpawner>().isActive = true;
        }

        if (points >= 30 && !spawners[2].GetComponent<WordSpawner>().isActive)
        {
            spawners[2].GetComponent<WordSpawner>().isActive = true;
        }

        if (points >= 60 && !spawners[3].GetComponent<WordSpawner>().isActive)
        {
            spawners[3].GetComponent<WordSpawner>().isActive = true;
        }
    }

    private void DisableSpawners()
    {
        foreach (GameObject spawner in spawners)
        {
            spawner.GetComponent<WordSpawner>().isActive = false;
        }
    }

    private void GameOver()
    {
        gameIsOver = true;
        GameObject[] wordBoxes = GameObject.FindGameObjectsWithTag("Word");
        foreach (var word in wordBoxes)
        {
            Destroy(word);
        }
        DisableSpawners();
        gameOverBox.SetActive(true);
    }

    public void RestartGame()
    {
        gameIsOver = false;
        gameOverBox.SetActive(false);
        pauseMenu.SetActive(false);
        DisableSpawners();
        foreach (var word in boxesOnScene)
        {
            Destroy(word);
        }
        timeRemaining = 30;
        timerIsRunning = true;
        points = 0;
        UpdatePoints();
        //EnableSpawners();
    }

    public void PauseGame()
    {
        timerIsRunning = false;
        boxesOnScene = GameObject.FindGameObjectsWithTag("Word");
        foreach (var word in boxesOnScene)
        {
            word.SetActive(false);
        }
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        foreach (var word in boxesOnScene)
        {
            word.SetActive(true);
        }
        timerIsRunning = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirector: MonoBehaviour
{
    public static int points;

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
    [SerializeField]
    private CountdownIntro countdownIntro;
    [SerializeField]
    private PointsMultiplier pointsManager;

    public float timeRemaining = 30;
    private bool timerIsRunning;
    private bool gameIsOver;
    private GameObject[] boxesOnScene;
    private bool childDestroyed;
    private AudioManager audioManager;

    private void Start()
    {
        timerIsRunning = true;
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (countdownIntro.isGameStarted)
        {
            if (!gameIsOver)
            {
                if (timerIsRunning)
                {
                    EnableSpawners();
                    if (timeRemaining >= 0)
                    {
                        timeRemaining -= Time.deltaTime;
                        timeText.text = Mathf.FloorToInt(timeRemaining % 60).ToString();
                    }
                    else
                    {
                        timeRemaining = 0;
                        timeText.text = timeRemaining.ToString();
                        timerIsRunning = false;
                        GameOver();
                    }
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
        if (GameManager.spawnState == GameManager.SpawnState.Word)
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
        if (GameManager.spawnState == GameManager.SpawnState.Sentence)
        {
            spawners[0].GetComponent<WordSpawner>().isActive = true;
            spawners[1].GetComponent<WordSpawner>().isActive = true;
            if (!childDestroyed)
            {
                if (spawners[2].GetComponent<WordSpawner>().isActive && spawners[3].GetComponent<WordSpawner>().isActive)
                {
                    GameObject.Destroy(spawners[2].transform.GetChild(0).gameObject);
                    GameObject.Destroy(spawners[3].transform.GetChild(0).gameObject);
                    childDestroyed = true;
                }
            }
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
        if (points > GameManager.highScore)
        {
            GameManager.highScore = points;
            GameManager.Instance.SaveHighScore();
        }
        gameOverBox.SetActive(true);
    }

    public void RestartGame()
    {
        gameOverBox.SetActive(false);
        pauseMenu.SetActive(false);
        DisableSpawners();
        if (!gameIsOver)
        {
            foreach (var word in boxesOnScene)
            {
                Destroy(word);
            }
        }
        gameIsOver = false;
        GameManager.spawnState = GameManager.SpawnState.Word;
        pointsManager.correctAnswers = 0;
        timeRemaining = 30;
        timeText.text = Mathf.FloorToInt(timeRemaining % 60).ToString();
        countdownIntro.isGameStarted = false;
        childDestroyed = false;
        StartCoroutine(countdownIntro.StartGame());
        timerIsRunning = true;
        points = 0;
        UpdatePoints();
    }

    public void PauseGame()
    {
        audioManager.PauseMusic("GameMusic");
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
        audioManager.UnPauseMusic("GameMusic");
        foreach (var word in boxesOnScene)
        {
            word.SetActive(true);
        }
        timerIsRunning = true;
    }

}

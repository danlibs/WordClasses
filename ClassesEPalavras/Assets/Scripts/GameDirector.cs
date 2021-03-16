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

    public float timeRemaining = 30;
    private bool timerIsRunning;
    private bool gameIsOver;

    private void Start()
    {
        timerIsRunning = true;
    }

    private void Update()
    {
        if (!gameIsOver)
        {
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
            EnableSpawners();
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
            spawners[0].SetActive(true);
            spawners[0].GetComponent<WordSpawner>().isActive = true;
        }

        if (points >= 10 && !spawners[1].GetComponent<WordSpawner>().isActive)
        {
            spawners[1].SetActive(true);
            spawners[1].GetComponent<WordSpawner>().isActive = true;
        }

        if (points >= 30 && !spawners[2].GetComponent<WordSpawner>().isActive)
        {
            spawners[2].SetActive(true);
            spawners[2].GetComponent<WordSpawner>().isActive = true;
        }

        if (points >= 60 && !spawners[3].GetComponent<WordSpawner>().isActive)
        {
            spawners[3].SetActive(true);
            spawners[3].GetComponent<WordSpawner>().isActive = true;
        }
    }

    private void DisableSpawners()
    {
        foreach (GameObject spawner in spawners)
        {
            spawner.SetActive(false);
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
        timeRemaining = 30;
        timerIsRunning = true;
        points = 0;
        UpdatePoints();
        spawners[0].GetComponent<WordSpawner>().SpawnWord();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager: MonoBehaviour
{
    public int points;

    [SerializeField]
    private TMP_Text pointsText;
    [SerializeField]
    private TMP_Text timeText;

    public float timeRemaining = 30;
    private bool timerIsRunning;

    private void Start()
    {
        timerIsRunning = true;
    }

    private void Update()
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
            }
        }
        
    }

    public void UpdatePoints()
    {
        pointsText.text = points.ToString();
    }
}

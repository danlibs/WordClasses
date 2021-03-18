using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownIntro : MonoBehaviour
{
    public bool isGameStarted;

    private TMP_Text countdownText;
    private float timeToInitiate = 3;
    private float timeRemaining;

    private void Awake()
    {
        countdownText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        timeRemaining = timeToInitiate;
        StartCoroutine(StartGame());
    }

    private void Update()
    {
        if (!isGameStarted)
        {
            StartCoroutine(StartGame());
        } 
    }

    private IEnumerator DisableIntro()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
        isGameStarted = true;
        timeRemaining = timeToInitiate;
        countdownText.fontSize = 850;
        countdownText.text = Mathf.FloorToInt(timeRemaining % 60).ToString();
    }

    public IEnumerator StartGame()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        countdownText.fontSize = 850;
        timeRemaining -= Time.deltaTime;
        countdownText.text = Mathf.FloorToInt(timeRemaining % 60).ToString();
        if (timeRemaining <= 0)
        {
            countdownText.fontSize = 115;
            countdownText.text = "COMEÇAR!";
            StartCoroutine(DisableIntro());
        }
    }
}

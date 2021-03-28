using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreTextController : MonoBehaviour
{
    private TextMeshProUGUI highScoreText;

    private void Awake()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        highScoreText.text = GameManager.Instance.LoadHighScore();
    }

    private void OnDisable()
    {
        
    }
}

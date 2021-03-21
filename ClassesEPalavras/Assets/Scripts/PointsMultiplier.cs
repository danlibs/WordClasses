using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsMultiplier : MonoBehaviour
{
    public int correctAnswers;

    [SerializeField]
    private TMP_Text pointsMultiplierText;

    private int pointsGained;

    private void Update()
    {
        if (correctAnswers <= 3)
        {
            pointsMultiplierText.text = "(x1)";
        }

        if (correctAnswers > 3 && correctAnswers <= 8)
        {
            pointsMultiplierText.text = "(x2!)";
        }

        if (correctAnswers > 8 && correctAnswers <= 12)
        {
            pointsMultiplierText.text = "(x5!)";
        }

        if (correctAnswers > 12 && correctAnswers <= 20)
        {
            pointsMultiplierText.text = "(x10!)";
        }

        if (correctAnswers > 20)
        {
            pointsMultiplierText.text = "(x20!)";
        }
    }

    public int GainPoints()
    {
        if (correctAnswers <= 3)
        {
            pointsGained = 2;
        }

        if (correctAnswers > 3 && correctAnswers <= 8)
        {
            pointsGained = 4;
        }

        if (correctAnswers > 8 && correctAnswers <= 12)
        {
            pointsGained = 10;
        }

        if (correctAnswers > 12 && correctAnswers <= 20)
        {
            pointsGained = 20;
        }

        if (correctAnswers > 20)
        {
            pointsGained = 40;
        }

        return pointsGained;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPointsToSentences : MonoBehaviour
{
    private InputField input;

    private void Awake()
    {
        input = GetComponent<InputField>();
    }

    public void InputToPoints()
    {
        GameManager.pointsToSentences = int.Parse(input.text);
    }

}

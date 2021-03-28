using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int highScore;

    public PlayerData(GameManager gameManager)
    {
        highScore = GameManager.highScore;
    }
}

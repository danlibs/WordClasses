using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameManager.FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    public static int highScore;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void SaveHighScore() => SaveSystem.SavePlayer(this);

    public string LoadHighScore()
    {
        if (SaveSystem.PathHasFile())
        {
            PlayerData data = SaveSystem.LoadPlayer();
            highScore = data.highScore;

            return highScore.ToString();
        }
        else
        {
            return "0";
        }
    }

}

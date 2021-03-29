using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum SpawnState
    {
        Word,
        Sentence
    }
    public static SpawnState spawnState;

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
    public static int pointsToSentences;
    public static bool isMusicEnabled = true;
    public static bool areSoundsEnabled = true;


    private void Awake()
    {
        //---ACTIVATE BEFORE BUILD---
        //SaveSystem.DeleteConfigsFile();
        //SaveSystem.DeleteSaveFile();
        //------------------------------//

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

    private void Start()
    {
        if (!SaveSystem.ConfigsPathHasFile())
        {
            pointsToSentences = 500;
        }
        else
        {
            LoadConfigurations();
        }
    }

    private void Update()
    {
        if (GameDirector.points <= pointsToSentences)
        {
            spawnState = SpawnState.Word;
        }
        else
        {
            spawnState = SpawnState.Sentence;
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        GameDirector.points = 0;
        spawnState = SpawnState.Word;
        SceneManager.LoadScene(sceneIndex);
    }

    public void SaveHighScore() => SaveSystem.SavePlayer(this);

    public string LoadHighScore()
    {
        if (SaveSystem.SavePathHasFile())
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

    public void SaveConfigurations() => SaveSystem.SaveConfigurations(this);

    public static void LoadConfigurations()
    {
        ConfigurationsData data = SaveSystem.LoadConfigurations();
        pointsToSentences = data.pointsToSentences;
        isMusicEnabled = data.enableMusic;
        areSoundsEnabled = data.enableSounds;
    }

}

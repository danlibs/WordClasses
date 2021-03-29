using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/highScore.ceuazul";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(gameManager);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/highScore.ceuazul";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveConfigurations(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/configurations.configs";
        FileStream stream = new FileStream(path, FileMode.Create);

        ConfigurationsData data = new ConfigurationsData(gameManager);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ConfigurationsData LoadConfigurations()
    {
        string path = Application.persistentDataPath + "/configurations.configs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ConfigurationsData data = formatter.Deserialize(stream) as ConfigurationsData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    public static void DeleteSaveFile()
    {
        string path = Application.persistentDataPath + "/highScore.ceuazul";
        File.Delete(path);
    }

    public static void DeleteConfigsFile()
    {
        string path = Application.persistentDataPath + "/configurations.configs";
        File.Delete(path);
    }

    public static bool SavePathHasFile()
    {
        string path = Application.persistentDataPath + "/highScore.ceuazul";
        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool ConfigsPathHasFile()
    {
        string path = Application.persistentDataPath + "/configurations.configs";
        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

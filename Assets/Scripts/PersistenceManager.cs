using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;

    public string username;

    public HighScore highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    private void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
        }
        if (highScore == null) {
            highScore = new HighScore
            {
                username = "-",
                score = 0
            };
        }
        Debug.Log("Highscore is: " + highScore);
    }

    public bool UpdateHighScore(HighScore newScore)
    {
        if (newScore.score > highScore.score)
        {
            highScore = newScore;
            SaveHighScore();
            return true;
        }
        return false;
    }

    [System.Serializable]
    public class HighScore
    {
        public int score;

        public string username;
    }

    [System.Serializable]
    class SaveData
    {
        public HighScore highScore;
    }
}

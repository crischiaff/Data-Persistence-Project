using System.Collections;
using System.Collections.Generic;
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

    private void LoadHighScore()
    {
        //TODO
    }

    public class HighScore
    {
        public int score;

        public string username;
    }

    class SaveData
    {
        public HighScore highScore;
    }
}

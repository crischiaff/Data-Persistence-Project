using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = "High Score: "
            + PersistenceManager.Instance.highScore.username
            + ": " + PersistenceManager.Instance.highScore.score;
    }

    public void StartGame()
    {
        FetchUserName();
        SceneManager.LoadScene(1);
    }

    public void FetchUserName()
    {
        PersistenceManager.Instance.username = inputField.text;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;

    void Start()
    {
        score.text = "MY SCORE: " + GameManager.score.ToString();
        highScore.text = "HIGH SCORE: " + GameManager.nicknameHighScore + " - " + GameManager.highScore.ToString();
        GameManager.SetScore();

        Debug.Log(score.text);
        Debug.Log(highScore.text);

        Invoke("GoMenu", 7f);
    }

    private void GoMenu()
    {
        SceneManager.LoadScene(0);
    } 
}

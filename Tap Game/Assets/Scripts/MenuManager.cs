using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private TMP_InputField nick;

    public void StartGame()
    {
        nick = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        GameManager.nickname = nick.text;
        GameManager.GetPlayerHighScore();
        SceneManager.LoadScene(1);
        Debug.Log(nick.text);
    }

    public void CreateUser()
    {
        Application.OpenURL("http://tapgameapp.reactivit.com.br");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

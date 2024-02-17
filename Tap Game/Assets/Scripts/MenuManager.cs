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
        GameManager.GetPlayer(nick.text);
        Debug.Log(GameManager.player.nick);
        //SceneManager.LoadScene(1);
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        //tratar a parte de usuario
        SceneManager.LoadScene(1);
    }

    public void CreateUser()
    {
        //site do game
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

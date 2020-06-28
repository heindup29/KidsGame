﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("ShapesScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}

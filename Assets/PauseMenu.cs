using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseUI;


    // Update is called once per frame
    private void Start()
    {
        pauseUI.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        pauseUI.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void pause()
    {
        Time.timeScale = 0;
    }

    public void resume()
    {
        Time.timeScale = 1;
        
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
    


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadInsertCoinSceneO()
    {
        SceneManager.LoadScene("Coin");
    }
    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void StartScene()
    {
        SceneManager.LoadScene("Start");
    }

    public void LoadScoreScene()
    {
        SceneManager.LoadScene("Score");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
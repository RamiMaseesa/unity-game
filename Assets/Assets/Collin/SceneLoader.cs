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
}

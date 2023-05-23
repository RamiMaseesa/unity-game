using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DontDestroyOnLoad : MonoBehaviour
{
    public string sceneName;
    public Scene activeScene;
    // Update is called once per frame
    void Update()
    {

        activeScene = SceneManager.GetActiveScene();
        sceneName = activeScene.name;
        if (sceneName == "Start")
        {
            GameObject[] musicObject = GameObject.FindGameObjectsWithTag("Audio");
            if (musicObject.Length > 1)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
        if (sceneName == "Game")
        {
            Destroy(gameObject);
        }
    }
}
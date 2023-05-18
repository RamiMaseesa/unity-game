using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public GameObject mCamera;
    public GameManager gameManager;
    // Update is called once per frame
    void Update()
    {
        mCamera = GameObject.Find("Camera");
        gameManager = mCamera.GetComponent<GameManager>();
    }

    public void ButtonPress()
    {
        gameManager.StartGame();
    }
}

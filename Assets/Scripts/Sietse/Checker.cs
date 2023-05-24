using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    //stores a gameobject and gamemanager
    public GameObject mCamera;
    public GameManager gameManager;
    // Update is called once per frame
    void Update()
    {
        //gameobject is gameobject called "Camera"
        mCamera = GameObject.Find("Camera");
        //gamemanager is a component in mCamera
        gameManager = mCamera.GetComponent<GameManager>();
    }

    public void ButtonPress()
    {
        //calls a method in gameManager
        gameManager.StartGame();
    }
}

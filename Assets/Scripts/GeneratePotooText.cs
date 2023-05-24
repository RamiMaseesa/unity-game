using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script makes a bool true so a nother script can start working
public class GeneratePotooText : MonoBehaviour
{
    private GameObject player = null;
    private PlayerJump PlayerJumpSc = null;

    void Start()
    {
        // find gameobject
        player = GameObject.Find("player");
        // GetComponent
        PlayerJumpSc = player.GetComponent<PlayerJump>();
        // change bool to true
        PlayerJumpSc.generate = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePotooText : MonoBehaviour
{
    private GameObject player = null;
    private PlayerJump PlayerJumpSc = null;

    void Start()
    {
        player = GameObject.Find("player");
        PlayerJumpSc = player.GetComponent<PlayerJump>();
        PlayerJumpSc.generate = true;
    }
}

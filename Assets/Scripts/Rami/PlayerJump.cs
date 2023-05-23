using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private char[] letters = {'z','x','c','v','b','n','m' };
    private GameObject potoo = null;
    private TMP_Text potooTextComponent = null;
    private int generatedNumber = 0;
    private Rigidbody2D Rigidbody2DPlayer = null;


    public bool generate = false;

    private void Start()
    {
        Rigidbody2DPlayer = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // generate a number and a char
        Generatie();
        // here i will start cheking if the player can jump
        JumpCheck();
    }

    private void Generatie()
    {
        if (generate)
        {
            generate = false;
            potoo = GameObject.Find("potoo");
            potooTextComponent = potoo.GetComponentInChildren<TMP_Text>();
            generatedNumber = Random.Range(0, letters.Length - 1);
            potooTextComponent.text = letters[generatedNumber].ToString();
        }
    }
    private void Force()
    {
        float speed = 13f;
        Rigidbody2DPlayer.velocity = Vector2.up * speed;
        generatedNumber = -1;
    }

    private void JumpCheck()
    {
        // the code will stop running the rest of the code if there is no potoo gameobject
        if (!GameObject.Find("potoo")) return;

        if (generatedNumber == 0 && Input.GetKeyDown(KeyCode.Z))
        {
            Force();
        }
        else if (generatedNumber == 1 && Input.GetKeyDown(KeyCode.X))
        {
            Force();
        }
        else if (generatedNumber == 2 && Input.GetKeyDown(KeyCode.C))
        {
            Force();
        }
        else if (generatedNumber == 3 && Input.GetKeyDown(KeyCode.V))
        {
            Force();
        }
        else if (generatedNumber == 4 && Input.GetKeyDown(KeyCode.B))
        {
            Force();
        }
        else if (generatedNumber == 5 && Input.GetKeyDown(KeyCode.N))
        {
            Force();
        }
        else if (generatedNumber == 6 && Input.GetKeyDown(KeyCode.M))
        {
            Force();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// this script makes the player jump
public class PlayerJump : MonoBehaviour
{
    private char[] letters = {'Z','X','C','V','B','N','M' };
    private GameObject potoo = null;
    private TMP_Text potooTextComponent = null;
    private int generatedNumber = 0;
    private Rigidbody2D Rigidbody2DPlayer = null;

    // public for later use
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
    /// <summary>
    /// this code generates a new char for the potoo prefab and assignes it 
    /// </summary>
    private void Generatie()
    {
        if (generate)
        {
            generate = false;
            potoo = GameObject.Find("potoo(Clone)");
            potooTextComponent = potoo.GetComponentInChildren<TMP_Text>();
            generatedNumber = Random.Range(0, letters.Length - 1);
            potooTextComponent.text = letters[generatedNumber].ToString();
        }
    }
    /// <summary>
    /// this code makes the player jump and stop him from jumping again
    /// </summary>
    private void Force()
    {
        float speed = 13f;
        Rigidbody2DPlayer.velocity = Vector2.up * speed;
        generatedNumber = -1;
    }

    /// <summary>
    /// this code checks if the player presses the right button
    /// </summary>
    private void JumpCheck()
    {
        // the code will stop running the rest of the code if there is no potoo gameobject
        if (!GameObject.Find("potoo(Clone)")) return;

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

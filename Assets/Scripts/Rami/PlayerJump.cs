using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private char[] letters = {'z','x','c','v','b','n','m' };
    private GameObject potoo = null;
    private TMP_Text potooTextComponent = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("potoo(Clone)") != null)
        {
            potoo = GameObject.Find("potoo(Clone)");
            potooTextComponent = potoo.GetComponent<TMP_Text>();

            potooTextComponent.text = letters[1].ToString();
        }



        //else
        //{
        //    potoo = null;
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private char[] letters = {'z','x','c','v','b','n','m' };
    private GameObject potoo = null;
    private TMP_Text potooTextComponent = null;
    private bool generate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (generate)
        {
            generate = false;
            potoo = GameObject.Find("potoo");
            potooTextComponent = potoo.GetComponentInChildren<TMP_Text>();
            potooTextComponent.text = letters[Random.Range(0,letters.Length)].ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    private GameObject animationSpeedObject;
    private AnimationSpeed animationSpeedScript;

    private Image heart11;
    private Image heart22;

    [SerializeField] GameObject heart;
    [SerializeField] GameObject heart2;

    [SerializeField] Sprite badHeart;

    void Start()
    {
        animationSpeedObject = GameObject.Find("player");
        animationSpeedScript = animationSpeedObject.GetComponent<AnimationSpeed>();

        heart11 = heart.GetComponent<Image>();
        heart22 = heart2.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animationSpeedScript.PlayerHp == 2)
        {
            heart11.sprite = badHeart;
        }
        else if (animationSpeedScript.PlayerHp == 1)
        {
            heart22.sprite = badHeart;
        }
    }
}

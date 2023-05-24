using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// changes the sprites of the hearts when hp lowers
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

    void Update()
    {
        // if the player hp is 2
        if(animationSpeedScript.PlayerHp == 2)
        {
            // change sprite to badheary
            heart11.sprite = badHeart;
        }
        else if (animationSpeedScript.PlayerHp == 1)
        {
            heart22.sprite = badHeart;
        }
        else if (animationSpeedScript.PlayerHp <= 0)
        {
            //when the player has 0 or less hp the game goes to Game Over scene
            SceneManager.LoadScene("Game Over");
        }
    }
}

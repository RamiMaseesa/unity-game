using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    private GameObject animationSpeedObject;
    private AnimationSpeed animationSpeedScript;

    void Start()
    {
        animationSpeedObject = GameObject.Find("player");
        animationSpeedScript = animationSpeedObject.GetComponent<AnimationSpeed>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            animationSpeedScript.PlayerHp--;
            Destroy(gameObject);
        }
    }
}

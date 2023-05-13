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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Something happened");
        if (collision.collider.CompareTag("player"))
        {
            animationSpeedScript.PlayerHp--;
            Destroy(gameObject);
        }
    }
}

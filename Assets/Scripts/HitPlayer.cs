using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// destroys gameobject after colliding with a player tag
// removes one hp from the player when colliding with a player tag
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
        // if th eobject collides with a player tag 
        if (collision.gameObject.CompareTag("player"))
        {
            // remove one PlayerHp
            animationSpeedScript.PlayerHp--;
            // destroy gameObject
            Destroy(gameObject);
        }
    }
}

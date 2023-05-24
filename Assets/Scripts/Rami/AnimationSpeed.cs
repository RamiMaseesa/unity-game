using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script changes the animation speed of the player
// this script sure that the player stayes at y -0.5
public class AnimationSpeed : MonoBehaviour
{
    private GameObject resetPosObject;
    private ResetPos resetPosScript;
    private Animator animator;
    private float clampedPos;

    // public for later use
    public int PlayerHp = 3;
    void Start()
    {
        animator = GetComponent<Animator>();
        resetPosObject = GameObject.Find("moving");
        resetPosScript = resetPosObject.GetComponent<ResetPos>();
    }

    void Update()
    {
        // the speed of the player is atleast 0 and has a max of 5.7
        animator.speed = (System.Math.Clamp(resetPosScript.speedValue * 0.3f, 0, 5.7f));

        // make sure the player stayes on y -0.5
        if (transform.position.y < -0.5f)
        {
            // Clamp the y position to the minimum value
            clampedPos = Mathf.Clamp(transform.position.y, -0.5f, Mathf.Infinity);
            transform.position = new Vector3(transform.position.x, clampedPos, transform.position.z);
        }
    }
}

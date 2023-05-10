using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{
    private GameObject resetPosObject;
    private ResetPos resetPosScript;
    private Animator animator;
    private float speed = 1;
    void Start()
    {
        animator = GetComponent<Animator>();
        resetPosObject = GameObject.Find("moving");
        resetPosScript = resetPosObject.GetComponent<ResetPos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (resetPosScript.increasSpeed)
        {
            speed *= 1.01f;
        }
        animator.speed = speed;
    }
}

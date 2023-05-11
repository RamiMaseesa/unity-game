using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{
    private GameObject resetPosObject;
    private ResetPos resetPosScript;
    private Animator animator;
    public float speed = 1;
    private float time = 0;
    private float duration = 3;
    void Start()
    {
        animator = GetComponent<Animator>();
        resetPosObject = GameObject.Find("moving");
        resetPosScript = resetPosObject.GetComponent<ResetPos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (resetPosScript.increaseSpeed) 
        {
            speed *= 1.01f;
        }
        animator.speed = speed;
    }
}

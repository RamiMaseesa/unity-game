using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{
    private GameObject resetPosObject;
    private ResetPos resetPosScript;
    private Animator animator;

    public int PlayerHp = 3;
    void Start()
    {
        animator = GetComponent<Animator>();
        resetPosObject = GameObject.Find("moving");
        resetPosScript = resetPosObject.GetComponent<ResetPos>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = (System.Math.Clamp(resetPosScript.speedValue * 0.5f, 0, 5.7f));
    }
}

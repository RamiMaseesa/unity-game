using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this code resets the pos of the object
// this code moves the object forward
public class MoveThePlatform : MonoBehaviour
{
    private GameObject resetPosObject;
    private ResetPos resetPosScript;
    private Vector3 resetPos = new Vector3 (12, 0.5f, 0);
    private Rigidbody2D rb;
    void Start()
    {
        resetPosObject = GameObject.Find("moving");
        resetPosScript = resetPosObject.GetComponent<ResetPos>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // if x is smaller than -12
        if(transform.position.x < -12)
        {
            // position is the resetpos
            gameObject.transform.position = resetPos;
        }
    }

    private void FixedUpdate()
    {
        // this code moves the player at a minimum speed of 0 and a max of 20
        rb.velocity = Vector2.left * Time.deltaTime * System.Math.Clamp(resetPosScript.speedValue * 100f, 0, 2000);
    }
}
// Old Code!!
//transform.Translate(Vector2.left * Time.deltaTime * System.Math.Clamp(resetPosScript.speedValue * 2f, 0, 20));
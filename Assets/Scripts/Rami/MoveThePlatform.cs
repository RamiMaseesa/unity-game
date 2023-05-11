using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThePlatform : MonoBehaviour
{
    private GameObject resetPosObject;
    private ResetPos resetPosScript;
    private float speedForPlatform = 1;
    private Vector3 resetPos = new Vector3 (14, -1, 0);
    void Start()
    {
        resetPosObject = GameObject.Find("moving");
        resetPosScript = resetPosObject.GetComponent<ResetPos>();
    }

    void Update()
    {
        if(transform.position.x < -13)
        {
            gameObject.transform.position = resetPos;
        }

        transform.Translate(Vector2.left * Time.deltaTime * resetPosScript.SpeedValue);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// moves the object till it is smaller than - 12 on the x axies
public class RemoveME : MonoBehaviour
{
    private GameObject resetPosObject;
    private ResetPos resetPosScript;
    // Start is called before the first frame update
    void Start()
    {
        resetPosObject = GameObject.Find("moving");
        resetPosScript = resetPosObject.GetComponent<ResetPos>();
    }

    // Update is called once per frame
    void Update()
    {
        // moves the gameobject
        transform.Translate(Vector2.left * Time.deltaTime * System.Math.Clamp((resetPosScript.speedValue * 2f), 0, 10));

        // if position is smaller than -12 destroy
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
}

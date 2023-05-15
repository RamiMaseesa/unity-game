using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        transform.Translate(Vector2.left * Time.deltaTime * System.Math.Clamp((resetPosScript.speedValue * 2f), 0, 20));

        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    private float endingPos = 6.75f;
    private int speedForBar = 3;
    private Vector3 startingPos;
    void Start()
    {
        startingPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speedForBar);

        if (gameObject.transform.position.x > endingPos || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            gameObject.transform.position = startingPos;
        }
    }
}

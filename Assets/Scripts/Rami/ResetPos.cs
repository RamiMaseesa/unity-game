using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    private float endingPos = 6.75f;
    private float speedForBar = 5;
    private Vector3 startingPos;

    // public omdat ik het in een ander script ga gebruiken
    public bool increasSpeed = false;

    void Start()
    {
        startingPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speedForBar);

        if (gameObject.transform.position.x > endingPos || Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.position = startingPos;
            speedForBar *= 1.02f;
            increasSpeed = true;
        }
    }
}

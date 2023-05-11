using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    private float endingPos = 6.75f;
    private float speedForBar = 5;
    private Vector3 startingPos;
    private bool keepMoving = true;
    private float time = 0;
    private int maxTime = 3;
    private new SpriteRenderer renderer;


    // public omdat ik het in een ander script ga gebruiken
    public bool increasSpeed = false;

    void Start()
    {
        startingPos = gameObject.transform.position;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!keepMoving)
        {
            time += Time.deltaTime;
            if (time > maxTime) 
            {
                keepMoving = true;
                time = 0;
            }
        }

        if (keepMoving)
        {
            renderer.color = Color.green;
            transform.Translate(Vector2.right * Time.deltaTime * speedForBar);
        }

        if (gameObject.transform.position.x > endingPos)
        {
            gameObject.transform.position = startingPos;
            speedForBar *= 1.02f;
            increasSpeed = true;
            keepMoving = false;
            renderer.color = Color.black;

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {

        }

    }
}

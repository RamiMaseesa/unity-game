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
    public float speedValue = 1;

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
            transform.localScale = new Vector3(0.3f, 1, 1);
            transform.Translate(Vector2.right * Time.deltaTime * (speedForBar + speedValue * 5));
        }

        if (gameObject.transform.position.x > endingPos)
        {
            gameObject.transform.position = startingPos;
            keepMoving = false;
            renderer.color = Color.black;
            transform.localScale = new Vector3(0.3f, 0.7f, 1);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ChecPosGreenBar();
            gameObject.transform.position = startingPos;
            keepMoving = false;
            renderer.color = Color.black;
            transform.localScale =  new Vector3(0.3f,0.7f,1);
        }
    }

    private void ChecPosGreenBar()
    {
        //normalized_value = (value - min_value) / (max_value - min_value)
        speedValue += ((float)(gameObject.transform.position.x - -6.75)) / ((float)(6.75 - -6.75)) / 2;
    }
}

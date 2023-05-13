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
    private int maxTime = 0;
    private new SpriteRenderer renderer;
    [SerializeField] GameObject Copie;


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
        // wait till the ingame world timer is bigger than 5
        if(Time.time > 5)
        {
            IfBarNotMoving();
            MoveTheBar();
            CheckSituation();
        }
    }

    private void IfBarNotMoving()
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
    }
    private void MoveTheBar()
    {
        if (keepMoving)
        {
            renderer.color = Color.red;
            transform.localScale = new Vector3(5f, 6, 1);
            transform.Translate(Vector2.right * Time.deltaTime * (speedForBar + speedValue * 5));
        }
    }
    private void CheckSituation()
    {
        // check for touching end or pressing space bar
        if (gameObject.transform.position.x > endingPos)
        {
            maxTime = Random.Range(2, 5);
            keepMoving = false;
            renderer.color = Color.black;
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
            transform.position = startingPos;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            StopTheBar();

            maxTime = Random.Range(2, 5);
            ChecPosGreenBar();
            keepMoving = false;
            renderer.color = Color.black;
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
            transform.position = startingPos;
        }
    }

    private void ChecPosGreenBar()
    {
        //normalized_value = (value - min_value) / (max_value - min_value)
        speedValue += ((float)(gameObject.transform.position.x - -6.75)) / ((float)(6.75 - -6.75)) / 2;
    }

    private void StopTheBar()
    {
        if (!GameObject.Find("copie(Clone)") && gameObject.transform.position.x >= -6.74)
        {
            Instantiate(Copie, transform.position, transform.rotation);
        }

    }
}

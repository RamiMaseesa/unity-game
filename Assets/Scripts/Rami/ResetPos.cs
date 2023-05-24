using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// this code checks what happens to the bar 
public class ResetPos : MonoBehaviour
{
    private float endingPos = 6.75f;
    private float speedForBar = 5;
    private Vector3 startingPos = new Vector3(-6.8f, -4.35f, 0);
    private Vector3 startingPos2 = new Vector3(-6.75f, -4.35f, 0);
    private bool keepMoving = true;
    private float time = 0;
    private int maxTime;
    private float timeTime;

    private new SpriteRenderer renderer;
    [SerializeField] GameObject Copie;

    private GameObject animationSpeedObject;
    private AnimationSpeed animationSpeedScript;

    // public omdat ik het in een ander script ga gebruiken
    public float speedValue = 1;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        animationSpeedObject = GameObject.Find("player");
        animationSpeedScript = animationSpeedObject.GetComponent<AnimationSpeed>();
        timeTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // wait till the ingame world timer is bigger than 5
        if(Time.time > timeTime + 5)
        {
            CheckIfClickedTooFast();
            IfBarNotMoving();
            MoveTheBar();
            CheckSituation();
        }
    }
    /// <summary>
    /// when the clicks when the bar has not appreared yet he loses a hp
    /// </summary>
    private void CheckIfClickedTooFast()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.x == -6.75)
        {
            animationSpeedScript.PlayerHp--;
        }
    }

    /// <summary>
    /// when the bar is not moving wait till time is more than max time after that keepmoving is true
    /// </summary>
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
    /// <summary>
    /// when keepmoving is true the player color is red the scale is changed and the bar moves
    /// </summary>
    private void MoveTheBar()
    {
        if (keepMoving)
        {
            renderer.color = Color.red;
            transform.localScale = new Vector3(5f, 6, 1);
            transform.Translate(Vector2.right * Time.deltaTime * (speedForBar + Math.Clamp(speedValue,1,10) * 5));
        }
    }
    /// <summary>
    /// this method will wait before doing the singend action
    /// </summary>
    /// <param name="delay">time before executin action</param>
    /// <param name="callback">action to be executed</param>
    /// <returns></returns>
    private IEnumerator DelayAction(float delay, Action callback)
    {
        // wait the singed amount
        yield return new WaitForSeconds(delay);
        // check if action is null if so skip it
        callback?.Invoke();
    }
    /// <summary>
    /// check if the player missed the bar or pressed on time
    /// </summary>
    private void CheckSituation()
    {
        // check for touching end or pressing space bar
        if (gameObject.transform.position.x > endingPos)
        {
            // give max time a random value
            maxTime = Random.Range(2, 5);
            keepMoving = false;
            renderer.color = Color.black;
            // change the scale
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
            transform.position = startingPos;
            animationSpeedScript.PlayerHp--;

            // StartCoroutine function
            StartCoroutine(DelayAction(0.3f, () =>
            {
                // Code to be executed after the delay
                transform.position = startingPos2;
            }));
        }
        else if (Input.GetKeyDown(KeyCode.Space) && gameObject.transform.position.x != -6.8)
        {
            StopTheBar();

            maxTime = Random.Range(2, 5);
            ChecPosGreenBar();
            keepMoving = false;
            renderer.color = Color.black;
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
            transform.position = startingPos;

            // StartCoroutine function
            StartCoroutine(DelayAction(0.3f, () =>
            {
                // Code to be executed after the delay
                transform.position = startingPos2;
            }));
        }
    }
    /// <summary>
    /// add value to the speedvalue
    /// </summary>
    private void ChecPosGreenBar()
    {
        //normalized_value = (value - min_value) / (max_value - min_value)
        speedValue += ((float)(gameObject.transform.position.x - -6.75)) / ((float)(6.75 - -6.75)) / 2;
    }
    /// <summary>
    /// instantiates a copie of itself at the pressed location
    /// </summary>
    private void StopTheBar()
    {
        if (!GameObject.Find("copie(Clone)") && gameObject.transform.position.x >= -6.74)
        {
            Instantiate(Copie, transform.position, transform.rotation);
        }
    }
}

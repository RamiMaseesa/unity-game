using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetCoin : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI[] buttons;   // Array to hold the button texts
    public TextMeshProUGUI calculateText;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI timerText;

    [SerializeField] int numberToCalculate;
    [SerializeField] int numberToCalculate2;
    [SerializeField] int answer;
    [SerializeField] int points;
    [SerializeField] int plusOrMinus;

    public float timerMax = 60f;
    private float timeLeft;

    void CalculatorMaker()
    {
        pointsText.text = $"Points: {points}";

        if (points == 3)
        {
            gameManager.GiveCoin();
        }

        numberToCalculate = NumberGenerator();
        numberToCalculate2 = NumberGenerator();
        int plusOrMinus = Random.Range(0, 2);
        //if plusOrMinus is 0 it perferoms the addition otherwise it does subtraction
        answer = plusOrMinus == 0 ? numberToCalculate + numberToCalculate2 : numberToCalculate - numberToCalculate2;
        //sets the text of what to calculate based on plusOrMinus if its 0 it does addition otherwise it will do subtraction
        calculateText.text = plusOrMinus == 0 ? $"{numberToCalculate} + {numberToCalculate2}" : $"{numberToCalculate} - {numberToCalculate2}";

        //generates a random number from 0 to 4
        int answerIndex = Random.Range(0, 4);

        //for i is 0 and i is smaller then buttons length (int) it will add 1 to i
        for (int i = 0; i < buttons.Length; i++)
        {
            //if is is equald to the random number set the text to the answer else set a random number
            if (i == answerIndex)
            {
                buttons[i].text = answer.ToString();
            }
            else
            {
                int number = NumberGenerator();
                buttons[i].text = number.ToString();
            }
        }
    }

    //checks button with the index its given
    public void ButtonCheck(int buttonIndex)
    {
        //if the buttons index text is equal to the answer
        if (buttons[buttonIndex].text == answer.ToString())
        {
            //add 1 point
            points++;
        }
        //else if points is larger then 0 
        else if (points > 0)
        {
            //decrease points by one
            points--;
        }

        // Generate a new calculation
        CalculatorMaker();
    }

    int NumberGenerator()
    {
        //retunrs a random number from 0 to 1000
        return Random.Range(0, 1001);
    }

    void Start()
    {
        //gets the GameManager component from a gameobject with tag "MainCamera"
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        //timeLeft is timerMax
        timeLeft = timerMax;
        //sets ponts to 0
        points = 0;
        //initial calculation
        CalculatorMaker();
    }

    void Update()
    {
        //every second it subtracts 1 from timeLeft
        timeLeft -= Time.deltaTime;
        //every frame timerText.text gets updated to the new current time
        timerText.text = $"Timer: {timeLeft.ToString("F0")}";   // Display the timer with 0 decimal places

        //if timeLeft is equal or smaller then 0
        if (timeLeft <= 0)
        {
            //loads the "Start" scene
            SceneManager.LoadScene("Start");   // Load the "Start" scene when the timer reaches 0
        }
    }
}

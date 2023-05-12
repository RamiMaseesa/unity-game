using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetCoin : MonoBehaviour
{
    public GameManager gameManager;
    GameObject cam;
    //public texts using the textmeshprougui
    public TextMeshProUGUI button1;
    public TextMeshProUGUI button2;
    public TextMeshProUGUI button3;
    public TextMeshProUGUI button4;
    public TextMeshProUGUI calculateText;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI timerText;

    //serializefielded intergers for the calculation
    [SerializeField] int numberA;
    [SerializeField] int numberB;
    [SerializeField] int numberC;
    [SerializeField] int numberToCalculate;
    [SerializeField] int numberToCalculate2;
    [SerializeField] int answer;
    [SerializeField] int plusOrMinus;
    [SerializeField] int points;

    public float timerMax = 60f;
    private float timeLeft;
    /// <summary>
    /// Makes a new calculation
    /// </summary>
    void CalculatorMaker()
    {
        //sets pointsText text
        pointsText.text = $"Points: {points}";

        //if points is equal to 3 do code
        if (points == 3)
        {
            gameManager.GiveCoin();
           // SceneManager.LoadScene("Start");
            //add coin to player script
        }

        //sets an interger by calling a method
        numberToCalculate = NumberGenerator();
        numberToCalculate2 = NumberGenerator();
        //random number 0 or 1
        plusOrMinus = Random.Range(0, 2);
        //prints int
        //print(plusOrMinus);
        numberA = NumberGenerator();
        numberB = NumberGenerator();
        numberC = NumberGenerator();
        //prints numbers
        //print(numberA);
        //print(numberB);
        //print(numberC);

        //if int is equal to 1 do code
        if (plusOrMinus == 1)
        {
            //inter * 2
            numberA *= 2;
            numberB *= 2;
            numberC *= 2;
            //answer is int + int
            answer = numberToCalculate + numberToCalculate2;
            //changes calculateText text to: using concat
            calculateText.text = $"{numberToCalculate} + {numberToCalculate2}";
        }
        //else do code
        else
        {
            //answer is int - int
            answer = numberToCalculate - numberToCalculate2;
            calculateText.text = $"{numberToCalculate} - {numberToCalculate2}";

        }
        //makes an random in that can be 0 1 2 3
        int switchInt = Random.Range(0, 4);
        //uses int to call a case
        switch (switchInt)
        {
            //when switch is 0 do code in case and continue
            case 0:
                //sets button text to int and converts the int to string
                button1.text = numberA.ToString();
                button2.text = numberB.ToString();
                button3.text = numberC.ToString();
                button4.text = answer.ToString();
                //stops case
                break;
            case 1:
                button1.text = numberA.ToString();
                button2.text = numberB.ToString();
                button3.text = answer.ToString();
                button4.text = numberC.ToString();
                break;
            case 2:
                button1.text = numberA.ToString();
                button2.text = answer.ToString();
                button3.text = numberB.ToString();
                button4.text = numberC.ToString();
                break;
            case 3:
                button1.text = answer.ToString();
                button2.text = numberA.ToString();
                button3.text = numberB.ToString();
                button4.text = numberC.ToString();
                break;
        }
    }

    /// <summary>
    /// button checks to see if the answer is in the button text
    /// </summary>
    public void Button1Check()
    {
        if (button1.text == answer.ToString())
        {
            points++;
            CalculatorMaker();
        }
        else
        {
            if (points > 0)
            {
                points--;
            }
            CalculatorMaker();
        }
    }
    public void Button2Check()
    {
        if (button2.text == answer.ToString())
        {
            points++;
            CalculatorMaker();
        }
        else
        {
            if (points > 0)
            {
                points--;
            }
            CalculatorMaker();
        }
    }
    public void Button3Check()
    {
        if (button3.text == answer.ToString())
        {
            points++;
            CalculatorMaker();
        }
        else
        {
            if (points > 0)
            {
                points--;
            }
            CalculatorMaker();
        }
    }
    public void Button4Check()
    {
        if (button4.text == answer.ToString())
        {
            points++;
            CalculatorMaker();
        }
        else
        {
            if (points > 0)
            {
                points--;
            }
            CalculatorMaker();
        }
    }
    /// <summary>
    /// number generator
    /// </summary>
    /// <returns>the random number</returns>
    int NumberGenerator()
    {
        //random number from 0 to 1001
        int i = Random.Range(0, 1001);
        //returns that number
        return i;
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        gameManager = cam.GetComponent<GameManager>();
        timeLeft = timerMax;
        //sets points to 0
        points = 0;
        //calls method
        CalculatorMaker();
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = $"Timer: {timeLeft.ToString("F0")}";
        if(timeLeft == 0)
        {
            SceneManager.LoadScene("Start");
        }
    }
}

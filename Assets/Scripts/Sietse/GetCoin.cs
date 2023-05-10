using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetCoin : MonoBehaviour
{
    public TextMeshProUGUI button1;
    public TextMeshProUGUI button2;
    public TextMeshProUGUI button3;
    public TextMeshProUGUI button4;
    public TextMeshProUGUI calculateText;

    //serializefielded intergers for the calculation
    [SerializeField] int numberA;
    [SerializeField] int numberB;
    [SerializeField] int numberC;
    [SerializeField] int numberToCalculate;
    [SerializeField] int numberToCalculate2;
    [SerializeField] int answer;
    [SerializeField] int plusOrMinus;
    /// <summary>
    /// Makes a new calculation
    /// </summary>
    void CalculatorMaker()
    {
        //sets an interger by calling a method
        numberToCalculate = NumberGenerator();
        numberToCalculate2 = NumberGenerator();
        plusOrMinus = Random.Range(0, 2);
        print(plusOrMinus);
        numberA = NumberGenerator();
        numberB = NumberGenerator();
        numberC = NumberGenerator();

        print(numberA);
        print(numberB);
        print(numberC);

        if (plusOrMinus == 1)
        {
            numberA *= 2;
            numberB *= 2;
            numberC *= 2;

            answer = numberToCalculate + numberToCalculate2;
            calculateText.text = $"{numberToCalculate} + {numberToCalculate2}";
        }
        else
        {
            answer = numberToCalculate - numberToCalculate2;
            calculateText.text = $"{numberToCalculate} - {numberToCalculate2}";

        }






        int switchInt = Random.Range(0, 4);
        switch (switchInt)
        {
            case 0:
                button1.text = numberA.ToString();
                button2.text = numberB.ToString();
                button3.text = numberC.ToString();
                button4.text = answer.ToString();
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
        //calls method
        CalculatorMaker();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

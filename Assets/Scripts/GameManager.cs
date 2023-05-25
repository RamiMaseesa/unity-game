using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject highScoreObj;
    [SerializeField] TextMeshProUGUI highscoreText;
    [SerializeField] CountMeters countScript = null;
    [SerializeField] GameObject canvasObj = null;
    [SerializeField] TextMeshProUGUI coinText = null;
    [SerializeField] GameObject coinObj = null;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject scoreTextObj = null;

    [SerializeField] GameObject tutorialText = null;
    [SerializeField] GameObject tutorialPic = null;
    public int coins;
    public int score;
    public int highScore;
    public string sceneName;
    public Scene activeScene;
    private static bool created = false;
    private static bool firstLoad = true;
    // Start is called before the first frame update
    private void Awake()
    {
        //if not created
        if (!created)
        {
            //dont destroys this object on load
            DontDestroyOnLoad(this.gameObject);
            //sets created to true
            created = true;
        }
        else
        {
            //destroys this gameobject
            Destroy(this.gameObject);
        }
        //gets the active
        activeScene = SceneManager.GetActiveScene();
        //sets string of active scene name
        sceneName = activeScene.name;

        if (sceneName == "Game")
        {
            tutorialText = GameObject.Find("TutorialText");
            tutorialPic = GameObject.Find("TutorialPic");
            if (firstLoad == true)
            {
                print("bitches");
                Destroy(tutorialPic, 10);
                Destroy(tutorialText, 10);
                firstLoad = false;
            }
            else
            {
                print("no bitches");
                Destroy(tutorialPic);
                Destroy(tutorialText);
            }
        }
    }
    void Start()
    {

        //gets the active
        activeScene = SceneManager.GetActiveScene();
        //sets string of active scene name
        sceneName = activeScene.name;
        //sets score to 0
        score = 0;
        //coins is set by playerprefs
        coins = PlayerPrefs.GetInt("Coins");

        //if scenename is start do code
        if (sceneName == "Start")
        {
            //if coins is equal or smaller then 3 do code
            if (coins <= 3)
            {
                //prints text in console
                print("You are poor. Getting more for you.");
                //sets coins to 3
                coins = 3;
            }
            else
            {
                print("nothing to do");
            }
            //prints int
            print(coins);
            //sets playerprefs "Coins" using int coins
            PlayerPrefs.SetInt("Coins", coins);
        }

    }

    public void GiveCoin()
    {
        //adds 1 to coins
        coins++;
        print("Giving coin");
        //loads start scene
        SceneManager.LoadScene("Start");
    }
    public void StartGame()
    {
        //if coins is bigger then 0 do code
        if (coins > 0)
        {
            //takes 1 from coins
            coins--;
            //loads scene "Game"
            SceneManager.LoadScene("Game");
        }
    }
    void Update()
    {
        PlayerPrefs.SetInt("Coins", coins);
        activeScene = SceneManager.GetActiveScene();
        sceneName = activeScene.name;
        //if scenename is equal to "" do code
        if (sceneName == "Game")
        {
            //canvasObj is gameobject with name Canvas
            canvasObj = GameObject.Find("Canvas");
            //countScript is component from canvasObject
            countScript = canvasObj.GetComponent<CountMeters>();
            //score is converted float to int from countScript
            score = (int)countScript.meters;

        }

        if (sceneName == "Score")
        {
            highScoreObj = GameObject.Find("HighscoreText");
            highscoreText = highScoreObj.GetComponent<TextMeshProUGUI>();
            highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        }

        if (sceneName == "Start")
        {
            coinObj = GameObject.Find("Coin");
            coinText = coinObj.GetComponent<TextMeshProUGUI>();
            coinText.text = $"Coins: {coins}";
        }
        if (sceneName == "Game Over")
        {
            scoreTextObj = GameObject.Find("Score");
            scoreText = scoreTextObj.GetComponent<TextMeshProUGUI>();
            scoreText.text = $"Score: {score}";
        }







        //sets score and in playerprefs and names it "score"
        PlayerPrefs.SetInt("score", score);
        //checks if score is higher then highScore
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
        }

    }

}

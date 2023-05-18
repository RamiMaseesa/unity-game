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
    public int coins;
    public int score;
    public int highScore;
    public string sceneName;
    public Scene activeScene;
    private static bool created = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);

            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
       
        score = 0;
        coins = PlayerPrefs.GetInt("Coins");

        if (sceneName == "Start")
        {
            if (coins == 0)
            {
                print("coins is zero getting more");
                coins += 3;
            }
            else if (coins <= 3 && coins! > 3)
            {
                while (coins != 3)
                {
                    coins++;
                }
            }
            else
            {
                print("nothing to do");
            }
            print(coins);
            PlayerPrefs.SetInt("Coins", coins);
        }
    }

    public void GiveCoin()
    {
        coins++;
        print("Giving coin");
        SceneManager.LoadScene("Start");
    }
    public void StartGame()
    {
        if(coins > 0)
        {
            coins--;
            SceneManager.LoadScene("Game");
        }
    }
    void Update()
    {
        activeScene = SceneManager.GetActiveScene();
        sceneName = activeScene.name;
        if (sceneName == "Game")
        {
            canvasObj = GameObject.Find("Canvas");
            countScript = canvasObj.GetComponent<CountMeters>();
            score = (int)countScript.meters;
        }

        if(sceneName == "Score")
        {
            highScoreObj = GameObject.Find("HighscoreText");
            highscoreText = highScoreObj.GetComponent<TextMeshProUGUI>();
            highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        }

        if(sceneName == "Start")
        {
            coinObj = GameObject.Find("Coin");
            coinText = coinObj.GetComponent<TextMeshProUGUI>();
            coinText.text = $"Coins: {coins}";
        }
        if(sceneName == "Game Over")
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

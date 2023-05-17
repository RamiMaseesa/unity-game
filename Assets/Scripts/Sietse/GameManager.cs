using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject HighscoreObj;
    [SerializeField] TextMeshProUGUI highscoreText;
    public int coins;
    private static bool created = false;
    [SerializeField] CountMeters countScript = null;
    [SerializeField] GameObject canvasObj = null;
    public int score;
    public int highScore;
    public string sceneName;
    public Scene activeScene;
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
            HighscoreObj = GameObject.Find("HighscoreText");
            highscoreText = HighscoreObj.GetComponent<TextMeshProUGUI>();
            highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        }








        PlayerPrefs.SetInt("score", score);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
        }

    }

}

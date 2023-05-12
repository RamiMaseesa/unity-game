using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int coins;
    private static bool created = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if(!created)
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
        coins = PlayerPrefs.GetInt("Coins");

        Scene activeScene = SceneManager.GetActiveScene();
        string sceneName = activeScene.name;
        if (sceneName == "Start")
        {
            if (coins == 0)
            {
                print("coins is zero getting more");
                coins += 3;
            }
            else if (coins <= 3 && coins !> 3)
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
    // Update is called once per frame
    void Update()
    {

    }
}

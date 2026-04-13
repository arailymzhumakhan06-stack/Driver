using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins;
    public int timeOfGame;
    public float timer;

    public Text coinsText;
    public Text timeText;
    

    public int speed;

    private static string playerName;
    bool alreadyDone = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        timeOfGame = 0;

        speed = 0;

        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();

        if (gameOver)
        {
            Time.timeScale = 0;
            if (!alreadyDone)
            {
                // Вместо сохранения счета, просто включаем панель GameOver
                gameOverPanel.SetActive(true);

                // Эту строку можно закомментировать или удалить, 
                // так как она ведет к сохранению рекордов
                // eventsObject.UnhideScoreSaving(); 

                alreadyDone = true;
            }
        }

        coinsText.text = "Coins: " + numberOfCoins;
        timeText.text = "Time: " + FormatTimeText();

        StartCoroutine(StartGame());
    }

    void UpdateTime()
    {
        if (isGameStarted)
        {
            timer += Time.deltaTime;
            timeOfGame = Convert.ToInt32(timer);
        }
    }

    

    string FormatTimeText()
    {
        return (timeOfGame.ToString()).PadLeft(3, ' ') + "s";
    }

    private IEnumerator StartGame()
    {
        if (SwipeManager.tap)
        {
            if (!isGameStarted)
            {
                var am = FindAnyObjectByType<AudioManager>();
                StartCoroutine(AudioManager.FadeOut(am.GetComponent<AudioSource>(), 1, 0.2f));
                am.PlaySound("StartingUp");

                yield return new WaitForSeconds(1);
                
                isGameStarted = true;

                Destroy(startingText);
            }
        }
    }

    public static string getPlayerName()
    {
        return playerName;
    }

    public static void SetPlayerName(string _playerName)
    {
        playerName = _playerName;
    }
}

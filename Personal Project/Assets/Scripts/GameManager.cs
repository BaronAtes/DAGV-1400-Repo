using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI winText;
    public bool isGameOver;
    private bool gameFinished = false;
    public bool isTimerRunning = false;
    private int timerStartTime;
    private int curTime;
    private int bonus;
    public int mailboxCount;
    void Awake()
    {
        Time.timeScale = 1;
        isGameOver = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimerCountdownRoutine());
        isTimerRunning = true;
        winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameFinished) return;
        mailboxCount = GameObject.FindGameObjectsWithTag("Mailbox").Length;
        if (isGameOver && gameFinished == false)
        {
            EndGame();
            gameFinished = true;
        }
        if (isGameOver == false)
        {
            gameOverText.gameObject.SetActive(false); // Keep game over UI hidden
        }
        if (isTimerRunning)
        {
            curTime = (60 - ((int)Time.time) + timerStartTime);
            bonus = curTime / 20 * 5;
            timerText.text = "Time: " + curTime;
        }
        if (mailboxCount == 0)
        {
            WinGame();
            gameFinished = true;
        }
    }

    public void EndGame()
    {
        gameOverText.gameObject.SetActive(true); // Make game over text appear
        Debug.Log("Game Over!");
        isTimerRunning = false;
        Time.timeScale = 0; // Stop time
    }
    public void WinGame()
    {
        winText.gameObject.SetActive(true); // Make victory text appear
        Debug.Log("You win!");
        isTimerRunning = false;
        UpdateScore(bonus);
        Time.timeScale = 0; // Stop time
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator TimerCountdownRoutine()
    {
        isTimerRunning = true;
        timerStartTime = (int)Time.time;
        yield return new WaitForSeconds(60);
        isGameOver = true;
    }
}

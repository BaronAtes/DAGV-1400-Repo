using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    private GameObject gameOverText;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        isGameOver = false;
    }
    void Start()
    {
        gameOverText = GameObject.Find("Game Over Text");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            EndGame();
        }
        else
        {
            gameOverText.gameObject.SetActive(false); // Keep game over UI hidden
        }
    }

    public void EndGame()
    {
        gameOverText.gameObject.SetActive(true); // Make game over text appear
        Debug.Log("Game Over!");
        Time.timeScale = 0; // Stop time
    }
}

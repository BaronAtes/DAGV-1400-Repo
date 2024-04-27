using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    private bool hasLost = false;
    private GameObject gameOverText;
    public AudioClip loseSound;
    private AudioSource managerAudio;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        isGameOver = false;
    }
    void Start()
    {
        gameOverText = GameObject.Find("Game Over Text");
        managerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver && hasLost == false)
        {
            EndGame();
            hasLost = true;
        }
        if (isGameOver == false)
        {
            gameOverText.gameObject.SetActive(false); // Keep game over UI hidden
        }
    }

    public void EndGame()
    {
        managerAudio.PlayOneShot(loseSound, 1.0f);
        gameOverText.gameObject.SetActive(true); // Make game over text appear
        Debug.Log("Game Over!");
        Time.timeScale = 0; // Stop time
    }
}

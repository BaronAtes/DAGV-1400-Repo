using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score; // Keep our score value
    public TextMeshProUGUI scoreText; // Visual text element to be modified
    // Start is called before the first frame update
    public void IncreaseScore(int amount) // This method, when called, increases the score by a predetermined amount set in score variable
    {
        score += amount;
        UpdateScoreText();
    }

    public void DecreaseScoreText(int amount)
    {
        score -= amount;
        UpdateScoreText();
    }

    public void UpdateScoreText() // This method updates the score in the HUD UI text.
    {
        scoreText.text = "Score: " + score;
    }
}

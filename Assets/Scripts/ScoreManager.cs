using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;// singleton
    public int score = 0;
    public Text scoreText;// assign your ScoreText UI here

    void Awake()
    {
        if (instance == null) instance = this;// set singleton instance
        else Destroy(gameObject);
    }

    public void AddPoints(int points)
    {
        score += points;// add to current score
        UpdateScoreText();// update UI
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;// update score display
    }
}

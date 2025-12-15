using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject startCanvas;     // Assign Start Screen Canvas
    public GameObject gameOverCanvas;  // Assign Game Over Canvas

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // Show start screen at beginning and pause game
        if (startCanvas != null)
            startCanvas.SetActive(true);

        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false);

        Time.timeScale = 0f; // pause game until player presses Start
    }

    // Called by Start Button
    public void StartGame()
    {
        if (startCanvas != null)
            startCanvas.SetActive(false);

        Time.timeScale = 1f; // resume game
    }

    // Called when the ship collides with an asteroid
    public void GameOver()
    {
        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(true);
        else
            Debug.LogError("GameOverCanvas is not assigned in GameManager!");

        // Reset score
        ScoreManager.instance.ResetScore();

        // Stop the game
        Time.timeScale = 0f;
    }

    // Called by Restart Button
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager: MonoBehaviour
{
    // Game Screen
    public Screen Screen;

    // UI
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public Button RestartButton;
    
    private static int _score;
    public int WaveCounter;
    public bool isGameActive;

    void Awake()
    {
        Screen = gameObject.GetComponent<Screen>();
        Debug.Log("Starting game!");
        StartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
    void StartGame()
    {
        _score = 0;
        isGameActive = true;
        WaveCounter = 1;
        ScoreText.text = "Score: 0";
        GameOverText.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        
    }

    public void AddScore(int score)
    {
        _score += score;
        ScoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
}

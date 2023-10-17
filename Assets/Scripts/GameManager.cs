using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager: MonoBehaviour
{
    // UI
    [FormerlySerializedAs("ScoreText")] public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverText;
    public Button RestartButton;
    
    private static int _score;
    public int WaveCounter;
    public bool isGameActive;

    void Awake()
    {
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
        scoreText.text = "Score: 0";
        GameOverText.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        
    }

    public void AddScore(int score)
    {
        _score += score;
        scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager: MonoBehaviour
{
    private const int PixelsPerUnit = 32; // pixels per unit
    private const float ScreenHeight = 16f;
    private const float ScreenWidth = 10f;
    // player size
    // TODO take from the actual collider, attached to player
    private const float PlayerSizeX = 34f / PixelsPerUnit;
    private const float PlayerSizeY = 48f / PixelsPerUnit;
    public Vector3 vPlayerCenterOffset = new Vector3(0f, PlayerSizeY / 2, 0f); // for targeting
    // clamps
    private const float ClampX = ScreenWidth / 2;
    private const float ClampY = ScreenHeight / 2;
    private const float ClampRadius = .1f;
    
    // bottom and top clamps for movement routine
    private const float ClampY0 = - ScreenHeight / 2;
    private const float ClampY1 = ScreenHeight / 2 - PlayerSizeY;

    // UI
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public Button RestartButton;
    
    private static int _score;
    public int WaveCounter;
    public bool isGameActive;

    void Start()
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
        ScoreText.text = "Score: 0";
        GameOverText.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        
    }

    public bool IsOffScreen(GameObject obj)
    {
        if (Mathf.Abs(obj.transform.position.x) > ClampX + ClampRadius)
        {
            return true;
        }
        if (Mathf.Abs(obj.transform.position.y) > ClampY + ClampRadius)
        {
            return true;
        }

        return false;
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

    public Vector3 GenerateRandomSpawnPoint()
    {
        var x = Random.Range(-ClampX, ClampX);
        var y = Random.Range(0, ClampY);
        return new Vector3(x, y, -1.0f);
    }
    
    // sprite pivot is at the bottom border, not the center
    // use clampY0, clampY1 constants instead of +/- ClampY to clamp movement
    public Vector3 MovementClamp(Vector3 position)
    {
        var x = Mathf.Clamp(position.x, -ClampX + PlayerSizeX / 2, ClampX - PlayerSizeX / 2);
        var y = Mathf.Clamp(position.y, ClampY0, ClampY1);
        return new Vector3(x, y, position.z);
    }
}

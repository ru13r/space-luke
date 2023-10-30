using Controllers;
using TMPro;
using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(PauseControl))]
    public class GameManager: MonoBehaviour
    {
        // UI
        [SerializeField] private TextMeshProUGUI scoreText;
    
        public int WaveCounter { get; set; }
    
        private static int _score;
        private PauseControl _pauseControl;

        private void Awake()
        {
            _pauseControl = GetComponent<PauseControl>();
            _pauseControl.ResumeGame();
            StartGame();
        }

        public bool IsGameActive => !_pauseControl.IsGamePaused;
    
        private void StartGame()
        {
            _score = 0;
            WaveCounter = 1;
            scoreText.text = "Score: 0";
        }

        public void AddScore(int score)
        {
            _score += score;
            scoreText.text = "Score: " + _score;
        }

        public void GameOver()
        {
            Invoke(nameof(ExecuteGameOver), 1.0f);
        }

        private void ExecuteGameOver()
        {
            _pauseControl.SetMenuTitle("Game over");
            _pauseControl.PauseGame();
        
        }
    }
}

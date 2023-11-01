using TMPro;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private const float GameOverDelay = 3.0f;
        private static int _score;

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI newTopScoreText;
        private bool _hasSetNewTopScore;
        private State _state;
        private UIManager _ui;
        public int WaveCounter { get; set; }

        public bool IsGameActive => _state == State.Active;

        private void Awake()
        {
            _ui = GetComponent<UIManager>();
            HighScore.HighScore.LoadScoresOrCreateNewList();
        }

        private void Start()
        {
            _score = 0;
            WaveCounter = 1;
            scoreText.text = "Score: 0";
            _state = State.Active;
            ResumeGame();
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            switch (_state)
            {
                case State.Active:
                    _state = State.Paused;
                    PauseGame();
                    _ui.ShowMenu();
                    break;
                case State.Paused:
                    _ui.HideMenu();
                    ResumeGame();
                    _state = State.Active;
                    break;
            }
        }

        public int GetScore()
        {
            return _score;
        }

        public void AddScore(int score)
        {
            _score += score;
            scoreText.text = "Score: " + _score;
            if (HighScore.HighScore.IsNewTopScore(_score) && !_hasSetNewTopScore)
            {
                _hasSetNewTopScore = true;
                newTopScoreText.gameObject.SetActive(true);
            }
        }


        public void GameOver()
        {
            _state = State.GameOver;
            _ui.ShowGameOver();
            if (HighScore.HighScore.IsNewHighScore(_score))
                Invoke(nameof(ShowHighScore), GameOverDelay);
            else
                Invoke(nameof(ShowMenu), GameOverDelay);
        }

        private void ShowHighScore()
        {
            _state = State.HighScoreEntry;
            PauseGame();
            _ui.ShowHighScore();
        }

        private void ShowMenu()
        {
            PauseGame();
            _ui.HideGameOver();
            _ui.ShowMenu();
        }

        private static void PauseGame()
        {
            Time.timeScale = 0f;
        }

        private static void ResumeGame()
        {
            Time.timeScale = 1;
        }


        private enum State
        {
            Active,
            Paused,
            GameOver,
            HighScoreEntry
        }
    }
}
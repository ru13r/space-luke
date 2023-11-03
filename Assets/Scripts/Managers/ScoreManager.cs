using Persistence;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI newTopScoreText;
        [SerializeField] private GameObject highScoreEntryUI;
        private int _bottomScore;

        private GameManager _gameManager;

        private bool _hasNewHighScore;
        private bool _hasNewTopScore;

        private int _score;

        // score range loaded from the saved high score list
        private int _topScore;

        private void Awake()
        {
            _gameManager = GetComponent<GameManager>();
            HighScoreList.Initialize();
            _topScore = HighScoreList.GetTopScore();
            _bottomScore = HighScoreList.GetBottomScore();
        }


        private void Start()
        {
            _score = 0;
            scoreText.text = "Score: 0";
            _hasNewTopScore = false;
            _hasNewHighScore = false;
        }

        public int GetScore()
        {
            return _score;
        }

        public void AddScore(int score)
        {
            _score += score;
            scoreText.text = "Score: " + _score;
            if (!_hasNewHighScore && _score > _bottomScore) _hasNewHighScore = true;
            if (!_hasNewTopScore && _score > _topScore)
            {
                _hasNewTopScore = true;
                newTopScoreText.gameObject.SetActive(true);
            }
        }

        public bool IsNewHighScore()
        {
            return _hasNewHighScore || _hasNewTopScore;
        }

        public void AddHighScore()
        {
            if (!_hasNewHighScore || !_hasNewTopScore) return;
            highScoreEntryUI.SetActive(true);
        }
    }
}
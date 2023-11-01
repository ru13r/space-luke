using Managers;
using TMPro;
using UnityEngine;

namespace HighScore
{
    public class HighScoreManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField playerNameField;
        private GameManager _gm;
        private int _score;
        private UIManager _ui;

        private void Awake()
        {
            _gm = GetComponent<GameManager>();
            _ui = GetComponent<UIManager>();
        }

        private void OnEnable()
        {
            playerNameField.Select();
        }

        public void ProcessInput()
        {
            AddHighScore(playerNameField.text);
        }

        private void AddHighScore(string playerName)
        {
            global::HighScore.HighScore.AddScore(_gm.GetScore(), playerName);
            _ui.HideHighScore();
            _ui.ShowMenu();
        }
    }
}
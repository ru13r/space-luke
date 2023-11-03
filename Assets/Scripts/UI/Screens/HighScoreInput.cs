using Managers;
using Persistence;
using TMPro;
using UnityEngine;

namespace UI.Screens
{
    public class HighScoreInput : GenericScreen
    {
        [SerializeField] private TMP_InputField playerNameField;

        private void OnEnable()
        {
            playerNameField.Select();
        }

        public void AddHighScore()
        {
            var scoreManager = FindObjectOfType<ScoreManager>();
            HighScoreList.AddScore(scoreManager.GetScore(), playerNameField.text);
            MyScreenManager.ChangeScreen(Globals.Screens.Menu);
        }
    }
}
using Managers;

namespace UI.Screens
{
    public class GameOver : GenericScreen
    {
        private const float GameOverDelay = 3.0f;

        private void OnEnable()
        {
            Invoke(nameof(AfterGameOver), GameOverDelay);
        }

        private void AfterGameOver()
        {
            if (FindObjectOfType<ScoreManager>().IsNewHighScore())
                MyScreenManager.ChangeScreen(Globals.Screens.HighScoreInput);
            else
                MyScreenManager.ChangeScreen(Globals.Screens.Menu);
        }
    }
}
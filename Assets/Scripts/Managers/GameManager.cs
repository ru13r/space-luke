using UI;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private ScreenManager _screenManager;

        public int WaveCounter { get; set; }

        public bool IsGameActive { get; private set; }

        private void Awake()
        {
            _screenManager = FindObjectOfType<ScreenManager>();
        }

        private void Start()
        {
            WaveCounter = 1;
            IsGameActive = true;
            ResumeGame();
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            if (IsGameActive)
            {
                IsGameActive = false;
                PauseGame();
                _screenManager.ChangeScreen(Globals.Screens.Menu);
            }
            else
            {
                if (!_screenManager.IsInMenu()) return;
                _screenManager.HideAllScreens();
                ResumeGame();
                IsGameActive = true;
            }
        }

        public void GameOver()
        {
            IsGameActive = false;
            _screenManager.ChangeScreen(Globals.Screens.GameOver);
        }

        private static void PauseGame()
        {
            Time.timeScale = 0f;
        }

        private static void ResumeGame()
        {
            Time.timeScale = 1f;
        }
    }
}
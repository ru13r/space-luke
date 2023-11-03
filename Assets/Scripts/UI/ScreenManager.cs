using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace UI
{
    public class ScreenManager : MonoBehaviour
    {
        [SerializeField] private GameObject menuScreen;
        [SerializeField] private GameObject optionsScreen;
        [SerializeField] private GameObject highScoreScreen;

        [SerializeField] [CanBeNull] private GameObject gameOverScreen;
        [SerializeField] [CanBeNull] private GameObject highScoreInputScreen;
        private Globals.Screens _screen;

        private Dictionary<Globals.Screens, GameObject> _screenDictionary;

        private void Awake()
        {
            // Initialize the screen dictionary
            _screenDictionary = new Dictionary<Globals.Screens, GameObject>
            {
                { Globals.Screens.Menu, menuScreen },
                { Globals.Screens.GameOver, gameOverScreen },
                { Globals.Screens.HighScoreInput, highScoreInputScreen },
                { Globals.Screens.Options, optionsScreen },
                { Globals.Screens.HighScore, highScoreScreen }
            };
        }

        public bool IsInMenu()
        {
            return _screen == Globals.Screens.Menu;
        }

        public void ChangeScreen(Globals.Screens screen)
        {
            _screen = screen;
            ActivateScreen(screen);
        }

        private void ActivateScreen(Globals.Screens screen)
        {
            HideAllScreens();
            if (_screenDictionary.TryGetValue(screen, out var screenToActivate))
                screenToActivate.SetActive(true);
        }

        public void HideAllScreens()
        {
            foreach (var screen in _screenDictionary.Values) screen.SetActive(false);
        }
    }
}
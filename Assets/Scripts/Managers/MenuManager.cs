using UnityEngine;
using UnityEngine.SceneManagement;
using Helpers;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        private enum OptionChoice
        {
            StartGame,
            HighScore,
            Options,
            Quit
        }
    
        public GameObject startGameTM;
        public GameObject highScoreTM;
        public GameObject optionsTM;
        public GameObject quitTM;
    
        private SelectableOption _selectedOption;
        private OptionChoice _optionChoice;
        // Start is called before the first frame update

        private void Awake()
        {
            _optionChoice = OptionChoice.StartGame;
            _selectedOption = startGameTM.GetComponent<SelectableOption>();
        }


        private void Start()
        {
            _selectedOption.Select();
        }

        // Update is called once per frame
        private void Update()
        {
            var nextChoice = _optionChoice;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                nextChoice = EnumCycle.CycleToNextOption(_optionChoice);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                nextChoice = EnumCycle.CycleToPrevOption(_optionChoice);
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                ConfirmSelection();
            }
        
            if (nextChoice == _optionChoice) return;
            _optionChoice = nextChoice;
            UpdateSelection();
        }

        private void UpdateSelection()
        {
            var selectedObject = _optionChoice switch
            {
                OptionChoice.StartGame => startGameTM,
                OptionChoice.HighScore => highScoreTM,
                OptionChoice.Options => optionsTM,
                OptionChoice.Quit => quitTM,
                _ => startGameTM
            };
            _selectedOption.DeSelect();
            _selectedOption = selectedObject.GetComponent<SelectableOption>();
            _selectedOption.Select();
        }
    
        private void ConfirmSelection()
        {
            switch (_optionChoice)
            {
                case OptionChoice.StartGame:
                    SceneManager.LoadScene("Sandbox");
                    break;
                case OptionChoice.Quit:
                    if (SceneManager.GetActiveScene().name == "MainMenu")
                    { 
                        Application.Quit();                
                    }
                    else
                    {
                        SceneManager.LoadScene("MainMenu");
                    }
                    break;
            }
        }
    }
}

using Managers;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class PauseControl : MonoBehaviour
    {
        [SerializeField] private GameObject menuCanvas;
        [SerializeField] private TextMeshProUGUI menuTitle;
        [SerializeField] private MenuManager menuManager;
    
        public bool IsGamePaused { get; private set;  }

        public void SetMenuTitle(string title)
        {
            menuTitle.text = title;
        }

        public void PauseGame()
        {
            IsGamePaused = true;
            Time.timeScale = 0f;
            menuManager.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(true);
        }
    
        public void ResumeGame()
        {
            IsGamePaused = false;
            Time.timeScale = 1;
            menuCanvas.gameObject.SetActive(false);
            menuManager.gameObject.SetActive(false);
        }
    
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            if (IsGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    
    }
}
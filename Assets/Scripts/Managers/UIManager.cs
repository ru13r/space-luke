using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject menuUI;
        [SerializeField] private GameObject highScoreUI;
        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private GameObject topScoreMessage;

        public void ShowMenu()
        {
            menuUI.gameObject.SetActive(true);
        }

        public void HideMenu()
        {
            menuUI.gameObject.SetActive(false);
        }

        public void ShowHighScore()
        {
            highScoreUI.gameObject.SetActive(true);
        }

        public void HideHighScore()
        {
            highScoreUI.gameObject.SetActive(false);
        }

        public void ShowGameOver()
        {
            gameOverUI.gameObject.SetActive(true);
        }

        public void HideGameOver()
        {
            gameOverUI.gameObject.SetActive(false);
        }
    }
}
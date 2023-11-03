using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject menuUI;
        [SerializeField] private GameObject highScoreUI;
        [SerializeField] private GameObject gameOverUI;

        public void ShowMenu()
        {
            menuUI.gameObject.SetActive(true);
        }

        public void HideHighScore()
        {
            highScoreUI.gameObject.SetActive(false);
        }
    }
}
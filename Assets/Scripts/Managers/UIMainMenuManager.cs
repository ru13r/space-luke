using UnityEngine;

namespace Managers
{
    public class UIMainMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject menuUI;
        [SerializeField] private GameObject highScoreList;

        public void ShowMenu()
        {
            menuUI.gameObject.SetActive(true);
        }

        public void HideMenu()
        {
            menuUI.gameObject.SetActive(false);
        }

        public void ShowHighScoreList()
        {
            highScoreList.gameObject.SetActive(true);
        }

        public void HideHighScoreList()
        {
            highScoreList.gameObject.SetActive(false);
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.MenuItems
{
    public class Quit : MenuItem
    {
        public override void Execute()
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
                Application.Quit();
            else
                SceneManager.LoadScene("MainMenu");
        }
    }
}
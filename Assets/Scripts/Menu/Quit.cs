using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class Quit : MenuItem
    {
        protected override void Execute()
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
                Application.Quit();
            else
                SceneManager.LoadScene("MainMenu");
        }
    }
}
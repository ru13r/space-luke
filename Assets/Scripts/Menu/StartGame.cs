using UnityEngine.SceneManagement;

namespace Menu
{
    public class StartGame : MenuItem
    {
        protected override void Execute()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name == "MainMenu"
                ? "Sandbox"
                : SceneManager.GetActiveScene().name);
        }
    }
}
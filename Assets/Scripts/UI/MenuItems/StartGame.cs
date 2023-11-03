using UnityEngine.SceneManagement;

namespace UI.MenuItems
{
    public class StartGame : MenuItem
    {
        public override void Execute()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name == Globals.Scenes.MainMenu
                ? Globals.Scenes.Sandbox
                : SceneManager.GetActiveScene().name);
        }
    }
}
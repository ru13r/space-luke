namespace UI.MenuItems
{
    public class HighScore : MenuItem
    {
        public override void Execute()
        {
            FindObjectOfType<ScreenManager>().ChangeScreen(Globals.Screens.HighScore);
        }
    }
}
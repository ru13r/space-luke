namespace UI.MenuItems
{
    public class Options : MenuItem
    {
        public override void Execute()
        {
            FindObjectOfType<ScreenManager>().ChangeScreen(Globals.Screens.Options);
        }
    }
}
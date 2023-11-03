using UnityEngine;

namespace UI.Screens
{
    public class Options : GenericScreen
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                MyScreenManager.ChangeScreen(Globals.Screens.Menu);
        }
    }
}
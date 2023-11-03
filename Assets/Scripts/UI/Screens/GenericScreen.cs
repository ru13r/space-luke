using UnityEngine;

namespace UI.Screens
{
    public abstract class GenericScreen : MonoBehaviour
    {
        protected ScreenManager MyScreenManager;

        private void Awake()
        {
            MyScreenManager = FindObjectOfType<ScreenManager>();
        }
    }
}
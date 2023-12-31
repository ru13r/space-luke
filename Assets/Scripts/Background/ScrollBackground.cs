using Managers;
using UnityEngine;

namespace Background
{
    public class ScrollBackground : MonoBehaviour
    {
        private const float Speed = 0.5f;
        private const float BackgroundHeight = 1332.0f / 32;

        private void LateUpdate()
        {
            transform.position += Vector3.down * (Time.deltaTime * Speed);
            if (!(transform.position.y <= -BackgroundHeight - GameScreen.ScreenHeight / 2)) return;
            transform.position = new Vector3(transform.position.x, BackgroundHeight - GameScreen.ScreenHeight / 2,
                Globals.BackgroundZOrder);
        }
    }
}
using UnityEngine;

namespace Background
{
    public class ScrollBackground : MonoBehaviour
    {
        private const float Speed = 0.5f;
        private const float BackgroundHeight = 1332.0f / 32;

        private GameObject _player;
    
        private void LateUpdate()
        {
            transform.position += Vector3.down * (Time.deltaTime * Speed);
            if (transform.position.y <= - BackgroundHeight - ScreenManager.ScreenHeight / 2 )
            {
                transform.position = new Vector3(0,  BackgroundHeight - ScreenManager.ScreenHeight / 2, 0 );
            }
        }
    }
}
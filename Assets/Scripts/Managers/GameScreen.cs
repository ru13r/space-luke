using UnityEngine;

namespace Managers
{
    public static class GameScreen
    {
        // Screen Dimensions
        public const float ScreenHeight = 16f;
        public const float ScreenWidth = 10f;
        // player ship object is required to calculate clamps
        public const float Right = ScreenWidth / 2;
        public const float Left = -ScreenWidth / 2;
        public const float Top = ScreenHeight / 2;
        public const float Bottom = -ScreenHeight / 2;
    
    
        public static Vector3 GenerateRandomSpawnPoint(Vector3 margin)
        {
            var x = Random.Range(Left - margin.x, Right + margin.x);
            var y = Random.Range(Top + margin.y, Top + margin.y + ScreenHeight/2);
            return new Vector3(x, y, 0f);
        }
    
        public static bool IsOffScreen(Vector3 position, Vector3 margin)
        {
            if (Mathf.Abs(position.x) > Right + margin.x)
            {
                return true;
            }
            if (Mathf.Abs(position.y) > Top + margin.y)
            {
                return true;
            }

            return false;
        }
        
    }
}

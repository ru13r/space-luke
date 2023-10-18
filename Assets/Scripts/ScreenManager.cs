using UnityEngine;

public class ScreenManager: MonoBehaviour
{
    // Screen Dimensions
    public const float ScreenHeight = 16f;
    public const float ScreenWidth = 10f;
    // player ship object is required to calculate clamps
    private const float ClampX = ScreenWidth / 2;
    private const float ClampY = ScreenHeight / 2;
    private const float ClampY0 = -ScreenHeight / 2;
    private const float ClampRadius = .1f;
    
    private float _clampY1;
    private float _playerSizeY;
    private GameObject _player;
    
    public void Start()
    {
        _player = GameObject.Find("Player");
    }
    
    // sprite pivot is at the bottom border, not the center
    // use clampY0, clampY1 constants instead of +/- ClampY to clamp movement
    public Vector3 MovementClamp(Vector3 position, (float x, float y) size)
    {
        _clampY1 = ScreenHeight / 2 - size.y;
        // bottom and top clamps for movement routine
        var x = Mathf.Clamp(position.x, -ClampX + size.x / 2, ClampX - size.x / 2);
        var y = Mathf.Clamp(position.y, ClampY0, _clampY1);
        return new Vector3(x, y, position.z);
    }
    
    public static Vector3 GenerateRandomSpawnPoint()
    {
        var x = Random.Range(-ClampX, ClampX);
        var y = Random.Range(ClampY, ClampY + ScreenHeight/2);
        return new Vector3(x, y, -1.0f);
    }
    
    public static bool IsOffScreen(GameObject obj)
    {
        if (Mathf.Abs(obj.transform.position.x) > ClampX + ClampRadius)
        {
            return true;
        }
        if (Mathf.Abs(obj.transform.position.y) > ClampY + ClampRadius)
        {
            return true;
        }

        return false;
    }
        
}

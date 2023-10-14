using UnityEngine;

public class Screen: MonoBehaviour
{
    // player ship object is required to calculate clamps
    private GameObject _player;
    
    private float _playerSizeY;
    private float _playerSizeX;
    private float _clampX = Globals.ScreenWidth / 2;
    private float _clampY = Globals.ScreenHeight / 2;
    private float _clampY0;
    private float _clampY1;
    private float _clampRadius = .1f; // 

    public void Start()
    {
        _player = GameObject.Find("Player");
        (_playerSizeX, _playerSizeY) = _player.GetComponent<Ship>().GetDimensions();
        _clampY0 = - Globals.ScreenHeight / 2;
        _clampY1 = Globals.ScreenHeight / 2 - _playerSizeY;
    }
    
    // sprite pivot is at the bottom border, not the center
    // use clampY0, clampY1 constants instead of +/- ClampY to clamp movement
    public Vector3 MovementClamp(Vector3 position)
    {
        // bottom and top clamps for movement routine
        var x = Mathf.Clamp(position.x, -_clampX + _playerSizeX / 2, _clampX - _playerSizeX / 2);
        var y = Mathf.Clamp(position.y, _clampY0, _clampY1);
        return new Vector3(x, y, position.z);
    }
    
    public Vector3 GenerateRandomSpawnPoint()
    {
        var x = Random.Range(-_clampX, _clampX);
        var y = Random.Range(0, _clampY);
        return new Vector3(x, y, -1.0f);
    }
    
    public bool IsOffScreen(GameObject obj)
    {
        if (Mathf.Abs(obj.transform.position.x) > _clampX + _clampRadius)
        {
            return true;
        }
        if (Mathf.Abs(obj.transform.position.y) > _clampY + _clampRadius)
        {
            return true;
        }

        return false;
    }
        
}

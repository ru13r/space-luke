using UnityEngine;

// Ship class is a parent class for all ships
// Player ship and enemy ships are derived from this class
public class Ship: MonoBehaviour
{
    // size and position
    private Collider2D _shipCollider;
    private Vector3 _size;
    
    // hit animation
    private HitAnimation _hitAnimation;
    
    
    public int Health { get; private set; }

    void Start()
    {
        if (gameObject.TryGetComponent(out Collider2D collider))
        {
            _shipCollider = collider;
            _size = _shipCollider.bounds.size;
        } 
        else
        {
            throw new MissingComponentException($"Failed to find center: {gameObject.name} has no collider attached to it.");
        }
        _hitAnimation = gameObject.AddComponent<HitAnimation>();
        
    }

    public Vector3 GetCenter() => _shipCollider.bounds.center;
    public (float, float) GetDimensions() => (_size.x, _size.y);

    public void SetHealth(int health) => Health = health;

    public void Damage(int damage)
    {
        Health -= damage;
        _hitAnimation.Play();
    }

    
}

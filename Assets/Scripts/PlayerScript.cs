using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // TODO make health bar
    // TODO show damage on the ship when health bar is low
    private Ship _ship;
    
    public ParticleSystem psDestroyed;

    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _ship = gameObject.GetComponent<Ship>();
        _ship.SetHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (_ship.Health <= 0)
        {
            var ps = Instantiate(psDestroyed, transform.position, psDestroyed.transform.rotation);
            Destroy(gameObject);
            ps.Emit(1);
            _gameManager.GameOver();
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            // TODO move damage to enemy projectile
            _ship.Damage(34);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            _ship.Damage(Globals.ShipCollisionDamage);
        }
    }
    
  
}

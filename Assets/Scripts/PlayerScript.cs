using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // TODO make health bar
    // TODO show damage on the ship when health bar is low
    
    private int _health;
    public ParticleSystem psDestroyed;

    private HitScript _hitScript;

    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _health = 100;
        _hitScript = GetComponent<HitScript>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_health <= 0)
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
            _hitScript.HitAnimation();
            // TODO move damage to enemy projectile
            _health -= 34;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            _hitScript.HitAnimation();
            _health -= 90;
        }
    }
  
}

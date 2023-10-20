using UnityEngine;

namespace Controllers
{
    public class PlayerScript : MonoBehaviour
    {
        [SerializeField] private ParticleSystem psDestroyed;
        
        // TODO make health bar
        // TODO show damage on the ship when health bar is low
        private Ship _ship;
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            _ship = gameObject.GetComponent<Ship>();
        }
        
        private void Start()
        {
            _ship.WeaponSystem.Arm();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_ship.GetHealth() <= 0)
            {
                var ps = Instantiate(psDestroyed, transform.position, psDestroyed.transform.rotation);
                Destroy(gameObject);
                ps.Emit(1);
                _gameManager.GameOver();
            }
        
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            var obj = other.gameObject;
            if (obj.layer == LayerMask.NameToLayer("EnemyProjectile"))
            {
                _ship.Damage(obj.GetComponent<Projectile>().Damage);
            }
            if (obj.layer == LayerMask.NameToLayer("Enemy"))
            {
                _ship.Damage(Globals.ShipCollisionDamage);
            }
        }
    
  
    }
}

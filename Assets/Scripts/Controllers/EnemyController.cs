using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers
{
    [RequireComponent(typeof(Ship))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem psDestroyed;
    
        // destruction
        private ParticleSystem _ps;
    
        private GameManager _gameManager;
        private Ship _ship;

        private void Awake()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            
            _ship = GetComponent<Ship>();
            _ship.WeaponSystem.Disarm();
            
            Invoke(nameof(ArmWeapons), Random.Range(1f, 3f));
        }
        private void Update()
        {
                if (_ship.GetHealth() <= 0)
                {
                    _ps = Instantiate(psDestroyed, transform.position, psDestroyed.transform.rotation);
                    Destroy(gameObject);
                    _ps.Emit(1);
                    _gameManager.AddScore(1000);
                }
        
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            var obj = other.gameObject;
            var projectile = other.gameObject;
            if (obj.layer == LayerMask.NameToLayer("PlayerProjectile"))
            {
                _ship.Damage(projectile.GetComponent<ProjectileController>().Damage);
                _gameManager.AddScore(200);
            }
            if (obj.layer == LayerMask.NameToLayer("Player"))
            {
                _ship.Damage(Globals.ShipCollisionDamage);
            }
        }
        private void ArmWeapons() => _ship.WeaponSystem.Arm();
        
    }
}

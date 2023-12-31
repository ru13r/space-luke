using Managers;
using Ships;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Ship))]
    public class EnemyScript : MonoBehaviour
    {
        [SerializeField] private ParticleSystem psDestroyed;

        // destruction
        private ParticleSystem _ps;
        private ScoreManager _scoreManager;
        private Ship _ship;

        private void Awake()
        {
            _scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
            _ship = GetComponent<Ship>();
        }

        private void Start()
        {
            _ship.WeaponSystem.Disarm();
            Invoke(nameof(ArmWeapons), Random.Range(1f, 3f));
        }

        private void Update()
        {
            if (_ship.GetHealth() <= 0)
            {
                _scoreManager.AddScore(_ship.GetScore());
                _ps = Instantiate(psDestroyed, transform.position, psDestroyed.transform.rotation);
                Destroy(gameObject);
                _ps.Emit(1);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var obj = other.gameObject;
            var projectile = other.gameObject;
            if (obj.layer == LayerMask.NameToLayer("PlayerProjectile"))
            {
                _ship.Damage(projectile.GetComponent<ProjectileScript>().Damage);
                _scoreManager.AddScore(Globals.HitScore);
            }

            if (obj.layer == LayerMask.NameToLayer("Player")) _ship.Damage(Globals.ShipCollisionDamage);
        }

        private void ArmWeapons()
        {
            _ship.WeaponSystem.Arm();
        }
    }
}
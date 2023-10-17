using System.Collections.Generic;
using UnityEngine;
using Weapons;
using Random = UnityEngine.Random;

namespace Controllers
{
    [RequireComponent(typeof(Ship))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem psDestroyed;
        private GameObject _player;
    
        // movement
        private const float Speed = 1.5f;
        private const float KeepDistanceToPlayer = 4.0f;
        private const float KeepDistanceInterval = 0.5f;
        private int _movingDirection;
    
        // destruction
        private ParticleSystem _ps;
    
        private GameManager _gameManager;
        private ScreenManager _screenManager;
        private Ship _ship;
        private (float, float) _dimensions;

        private void Awake()
        {
            // resolve other components
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            _screenManager = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
            _player = GameObject.Find("Player");
        
            // ship
            _ship = GetComponent<Ship>();
            _ship.SetHealth(20);
            _dimensions = _ship.GetDimensions();
            
            _ship.WeaponSystem.Disarm();
            Invoke(nameof(ArmWeapons), Random.Range(1f, 3f));
        
            // movement
            _movingDirection = Random.value > .5f ? 1 : -1;

        }
        private void Update()
        {
            if (_gameManager.isGameActive)
            {
                MovementRoutine();
                if (_ship.Health <= 0)
                {
                    _ps = Instantiate(psDestroyed, transform.position, psDestroyed.transform.rotation);
                    Destroy(gameObject);
                    _ps.Emit(1);
                    _gameManager.AddScore(1000);
                }
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
        
        private void MovementRoutine()
        {
            var playerPosition = _player.transform.position;
            var position = transform.position;
            var moveDirection = (playerPosition - position).normalized;
            if (Vector3.Distance(playerPosition, position) >= KeepDistanceToPlayer + KeepDistanceInterval)
            {
                transform.Translate(Speed * Time.deltaTime * moveDirection);
            }
            if (Vector3.Distance(playerPosition, position) <= KeepDistanceToPlayer - KeepDistanceInterval)
            {
                transform.Translate(- Speed * Time.deltaTime * moveDirection);
            }
            else
            {
                var orthogonalDirection = Vector3.Cross(moveDirection, Vector3.forward) * _movingDirection;
                transform.Translate(- Speed * Time.deltaTime * orthogonalDirection);
            }
            if (_screenManager.MovementClamp(transform.position, _dimensions) != transform.position)
            {
                _movingDirection = -_movingDirection;
            }
        }
    }
}

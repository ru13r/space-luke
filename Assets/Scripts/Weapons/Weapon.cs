using System.Collections;
using UnityEngine;
using Controllers;

namespace Weapons
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        // weapon stats
        [SerializeField] private WeaponStats stats;
        public bool IsArmed { get; set; }
        
        private GameManager _gameManager;

        // state
        private bool _readyToShoot = true;
        
        // projectile parameters
        Vector3 _projectileDirection = Vector3.zero;
        private Quaternion _projectileRotation = Quaternion.identity;
        
        // unity lifecycle
        private void Awake()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            IsArmed = true;
        }

        private void Update()
        {
            if (!_gameManager.isGameActive) IsArmed = false;
        }

        public void SetProjectileDirectionAndRotation(Vector3 direction, Quaternion rotation)
        {
            _projectileDirection = direction.normalized;
            _projectileRotation = rotation;
        }

        public void Attack()
        {
            if (IsArmed && _readyToShoot)
            {
                StartCoroutine(nameof(BurstRoutine));
            }
        }

        public bool IsReady() => _readyToShoot;

        private IEnumerator BurstRoutine()
        {
            _readyToShoot = false;
            for (var i = 0; i < stats.Burst; i++)
            {
                SingleAttack();
                yield return new WaitForSeconds(1 / stats.FireRate);
                
            }
            yield return new WaitForSeconds(stats.BurstReload);
            _readyToShoot = true;
        }
        
        private void SingleAttack()
        {
            var spread = stats.SpreadAngle / 2;
            var spreadRotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(-spread, spread)));
            
            var projectile = Instantiate(
                stats.ProjectilePrefab, 
                transform.position,
                _projectileRotation);
            var projectileController = projectile.GetComponent<Projectile>();
            projectileController.Initialize(gameObject.tag, stats.Range, spreadRotation * _projectileDirection);
        }
    }
}


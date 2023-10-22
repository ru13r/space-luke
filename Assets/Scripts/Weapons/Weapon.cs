using System.Collections;
using UnityEngine;
using Projectiles;

namespace Weapons
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        // weapon and projectile stats
        [SerializeField] protected WeaponStats weaponStats;
        public bool IsArmed { get; set; }
        private GameManager _gameManager;

        // state
        protected bool ReadyToShoot = true;
        
        // projectile parameters
        protected Vector3 ProjectileDirection = Vector3.zero;
        protected Quaternion ProjectileRotation = Quaternion.identity;
        
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
            ProjectileDirection = direction.normalized;
            ProjectileRotation = rotation;
        }

        public void Attack()
        {
            if (IsArmed && ReadyToShoot)
            {
                StartCoroutine(nameof(BurstRoutine));
            }
        }

        public bool IsReady() => ReadyToShoot;

        protected virtual IEnumerator BurstRoutine()
        {
            ReadyToShoot = false;
            for (var i = 0; i < weaponStats.Burst; i++)
            {
                SingleAttack();
                yield return new WaitForSeconds(1 / weaponStats.FireRate);
                
            }
            yield return new WaitForSeconds(weaponStats.BurstReload);
            ReadyToShoot = true;
        }
        
        protected virtual void SingleAttack()
        {
            var spread = weaponStats.SpreadAngle / 2;
            var spreadRotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(-spread, spread)));
            var projectile = Instantiate(
                weaponStats.ProjectileStats.ProjectilePrefab, 
                transform.position,
                ProjectileRotation);
            var projectileController = projectile.GetComponent<ProjectileScript>();
            projectileController.Initialize(gameObject.tag, weaponStats, spreadRotation * ProjectileDirection);
        }
    }
}


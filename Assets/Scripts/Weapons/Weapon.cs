using System.Collections;
using UnityEngine;
using Controllers;
using UnityEngine.UIElements;
using WeaponControllers;

namespace Weapons
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        // weapon stats
        [SerializeField] private WeaponStats stats;
        public GameObject weaponControllerObject;
        
        
        private IWeaponController _weaponController;
        private GameManager _gameManager;
        
        private bool _readyToShoot = true;
        private bool _isArmed = true;

        private void Awake()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            _weaponController = weaponControllerObject.GetComponent<IWeaponController>();
            _isArmed = true;
        }

        private void Update()
        {
            if (!_gameManager.isGameActive) _isArmed = false;
        }

        public void Arm() => _isArmed = true;
        public void Disarm() => _isArmed = false;
        public void Shoot()
        {
            if (_readyToShoot && _isArmed)
            {
                StartCoroutine(nameof(ShootRoutine));
            }
        }
        private IEnumerator ShootRoutine()
        {
            _readyToShoot = false;
            var attackVector = _weaponController.GetAttackVector();
            var spread = stats.SpreadAngle / 2;
            var spreadRotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(-spread, spread)));
            var attackRotation = spreadRotation * _weaponController.GetAttackRotation();
            var projectile = Instantiate(
                stats.ProjectilePrefab, 
                transform.position,
                attackRotation);
            var projectileController = projectile.GetComponent<Projectile>();
            projectileController.Initialize(gameObject.tag, stats.Range, spreadRotation * attackVector);
            yield return new WaitForSeconds(1 / stats.FireRate);
            _readyToShoot = true;
        }
    }
}


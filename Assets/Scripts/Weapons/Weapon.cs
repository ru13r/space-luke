using System;
using System.Collections;
using UnityEngine;
using Controllers;
using WeaponControllers;

namespace Weapons
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        public WeaponStats stats;
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
            var attackRotation = _weaponController.GetAttackRotation();
            var projectile = Instantiate(
                stats.ProjectilePrefab, 
                transform.position,
                attackRotation);
            var projectileController = projectile.GetComponent<Projectile>();
            projectileController.Initialize(gameObject.tag, stats.Range, attackVector);
            yield return new WaitForSeconds(1 / stats.FireRate);
            _readyToShoot = true;
        }
    }
}


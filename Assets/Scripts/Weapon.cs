using System;
using System.Collections;
using UnityEngine;

public enum WeaponType
{
    laserGun,
    plasmaGun,
    kineticGun,
    missileLauncher
}

public abstract class Weapon : MonoBehaviour
{
    // Weapon parameters
    private float _fireRate;
    private float _range;
    private float _damage;
    
    // TODO speed is derived from range
    private float _projectileSpeed;
    
    // Weapon position realtive to owner
    private GameObject _weaponOwner;
    private GameObject _weaponTarget;
    private Vector3 _relativePosition;
    
    // projectile prefab
    public GameObject projectilePrefab;
    
    // Weapon state
    private bool _allowFire;
    private bool _isFiring;

    private void Start()
    {
        _weaponTarget = GameObject.Find("Player");
        _projectileSpeed = 30f;
    }

    public Vector3 setTarget(GameObject targetObject)
    {
        Vector3 targetPosition = targetObject.GetComponent<Ship>().GetCenter();
        return (targetPosition - transform.position).normalized;
    }

    public IEnumerator fire()
    {
        _allowFire = false;
        Vector3 fireDirection = (setTarget(_weaponTarget) - transform.position).normalized;
        GameObject projectile = Instantiate(projectilePrefab, transform.position + fireDirection * 0.3f, transform.rotation);
        // TODO move to EnemyProjectileScript
        projectile.GetComponent<Rigidbody2D>().velocity = (fireDirection * _projectileSpeed);
        yield return new WaitForSeconds(1 / _fireRate);
        _allowFire = true;
        
    }
}

public class LaserGun : Weapon
{

}
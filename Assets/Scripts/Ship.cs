using System;
using UnityEngine;
using Weapons;

[RequireComponent(typeof(Collider2D))]
public class Ship: MonoBehaviour
{
    public WeaponSystem WeaponSystem => weaponSystem;
    [SerializeField] private GameObject weaponSystemObject;
    // size and position
    private Collider2D _collider;
    private Vector3 _size;
    [SerializeField] private WeaponSystem weaponSystem;
    private HitAnimation _hitAnimation;
    
    public int Health { get; private set; }
    private void Awake()
    {
        weaponSystem = weaponSystemObject.GetComponent<WeaponSystem>();
        _hitAnimation = gameObject.AddComponent<HitAnimation>();
        _collider = gameObject.GetComponent<Collider2D>();
        _size = _collider.bounds.size;
    }


    public Vector3 GetCenter()
    {
        if (_collider)
        {
            return _collider.bounds.center;   
        }
        else
        {
            return Vector3.zero;
        }
    }

 
    public (float, float) GetDimensions() => (_size.x, _size.y);

    public void SetHealth(int health) => Health = health;

    public void Damage(int damage)
    {
        Health -= damage;
        _hitAnimation.Play();
    }
    
}

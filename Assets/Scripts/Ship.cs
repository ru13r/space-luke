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
    
    [SerializeField] private int maxHealth;
    private int _health;
    private void Awake()
    {
        weaponSystem = weaponSystemObject.GetComponent<WeaponSystem>();
        _hitAnimation = gameObject.AddComponent<HitAnimation>();
        _collider = gameObject.GetComponent<Collider2D>();
        _size = _collider.bounds.size;
        _health = maxHealth;
    }
    

 
    public (float, float) GetDimensions() => (_size.x, _size.y);

    public void Damage(int damage)
    {
        _health -= damage;
        _hitAnimation.Play();
    }

    public int GetHealth() => _health;

}

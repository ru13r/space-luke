using System;
using UnityEngine;
using Weapons;

[RequireComponent(typeof(Collider2D))]
public class Ship: MonoBehaviour
{
    public WeaponSystem WeaponSystem => weaponSystem;
    [SerializeField] private GameObject weaponSystemObject;
    [SerializeField] private WeaponSystem weaponSystem;
    private HitAnimation _hitAnimation;
    
    [SerializeField] private int maxHealth;
    private int _health;
    private void Awake()
    {
        weaponSystem = weaponSystemObject.GetComponent<WeaponSystem>();
        _hitAnimation = gameObject.AddComponent<HitAnimation>();
        _health = maxHealth;
    }

    public void Damage(int damage)
    {
        _health -= damage;
        _hitAnimation.Play();
    }

    public int GetHealth() => _health;

}

using System;
using Enemies;
using UnityEngine;
using UnityEngine.Serialization;
using Weapons;

public class Ship: MonoBehaviour
{
    [SerializeField] private ShipStats shipStats;
    
    public WeaponSystem WeaponSystem => weaponSystem;
    [SerializeField] private GameObject weaponSystemObject;
    [SerializeField] private WeaponSystem weaponSystem;
    private HitAnimation _hitAnimation;

    private int _health;
    private void Awake()
    {
        weaponSystem = weaponSystemObject.GetComponent<WeaponSystem>();
        _hitAnimation = gameObject.AddComponent<HitAnimation>();
        _health = shipStats.health;
    }

    public void Damage(int damage)
    {
        _health -= damage;
        _hitAnimation.Play();
    }

    public int GetHealth() => _health;
    public int GetScore() => shipStats.score;
}

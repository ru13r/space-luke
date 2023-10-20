using System;
using Ships;
using UnityEngine;
using UnityEngine.Serialization;
using Weapons;

public class Ship: MonoBehaviour
{
    [SerializeField] private ShipStats shipStats;
    [SerializeField] private GameObject weaponSystemObject;
    [NonSerialized] public WeaponSystem WeaponSystem;
    private HitAnimation _hitAnimation;

    private int _health;
    private void Awake()
    {
        WeaponSystem = weaponSystemObject.GetComponent<WeaponSystem>();
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

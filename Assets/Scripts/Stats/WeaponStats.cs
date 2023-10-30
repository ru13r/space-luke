using Stats;
using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    [CreateAssetMenu(fileName = "NewWeaponStats", menuName = "My Objects/Weapon Stats", order = 0)]
    public class WeaponStats : ScriptableObject
    {
        [SerializeField] public string weaponName;
        [SerializeField] private float fireRate;
        [SerializeField] private float spreadAngle;
        [SerializeField] private int burst = 1;
        [SerializeField] private float burstReloadTime = 0;

        [FormerlySerializedAs("projectile")] [SerializeField] private ProjectileStats projectileStats;

        public string WeaponName => weaponName;
        public float FireRate => fireRate;
        public float SpreadAngle => spreadAngle;
        public int Burst => burst;
        public float BurstReload => burstReloadTime;
        public ProjectileStats ProjectileStats => projectileStats;
    }
}
using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    [CreateAssetMenu(fileName = "NewWeaponStats", menuName = "My Objects/Weapon Stats", order = 0)]
    public class WeaponStats : ScriptableObject
    {
        [SerializeField] public string weaponName;
        [SerializeField] private float fireRate;
        [SerializeField] private float range;
        [SerializeField] private float spreadAngle;
        [SerializeField] private GameObject projectilePrefab;

        public string WeaponName => weaponName;
        public float FireRate => fireRate;
        public float Range => range;
        public float SpreadAngle => spreadAngle;
        public GameObject ProjectilePrefab => projectilePrefab;
    }
}
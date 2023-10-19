using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "NewWeaponStats", menuName = "My Objects/Weapon Stats", order = 0)]
    public class WeaponStats : ScriptableObject
    {
        [SerializeField] public string weaponName;
        [SerializeField] private float fireRate;
        [SerializeField] private float range;
        [SerializeField] private GameObject projectilePrefab;

        public string WeaponName => weaponName;
        public float FireRate => fireRate;
        public float Range => range;
        public GameObject ProjectilePrefab => projectilePrefab;
    }
}
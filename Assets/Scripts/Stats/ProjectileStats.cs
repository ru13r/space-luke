using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(fileName = "NewProjectile", menuName = "My Objects/Projectile Stats", order = 0)]
    public class ProjectileStats : ScriptableObject
    {
        [SerializeField] private string projectileName;
        [SerializeField] private int damage = 20;
        [SerializeField] private float speed = 4;
        [SerializeField] private float range = 4;
        [SerializeField] private GameObject projectilePrefab;
        
        public string ProjectileName => projectileName;
        public int Damage => damage;
        public float Speed => speed;
        public float Range => range;
        public GameObject ProjectilePrefab => projectilePrefab;
        
    }
}
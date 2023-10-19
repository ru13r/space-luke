using UnityEngine;

namespace Projectiles
{
    [CreateAssetMenu(fileName = "NewProjectile", menuName = "My Objects/Projectile Stats", order = 0)]
    public class ProjectileStats : ScriptableObject
    {
        [SerializeField] private string projectileName;
        [SerializeField] private int damage = 20;
        [SerializeField] private int speed = 4;
        
        public string ProjectileName => projectileName;
        public int Damage => damage;
        public int Speed => speed;
    }
}
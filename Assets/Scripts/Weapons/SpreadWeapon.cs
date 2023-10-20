using UnityEngine;

namespace Weapons
{
    public class SpreadWeapon: Weapon
    {
        [SerializeField] private float spreadAngle = 30.0f;
        
        [Range(2,15)]
        [SerializeField] private int projectileCount = 3;
        protected override void SingleAttack()
        {
            var projectileParamsSaved = (ProjectileDirection, ProjectileRotation);
            var spreadStep = spreadAngle / (projectileCount-1);
            
            for (var i = 0; i < projectileCount; i++)
            {
                var rotation = Quaternion.Euler(0f, 0f, -spreadAngle / 2 + i * spreadStep);
                ProjectileDirection = rotation * projectileParamsSaved.ProjectileDirection;
                ProjectileRotation = rotation * projectileParamsSaved.ProjectileRotation;
                base.SingleAttack();
            }
            (ProjectileDirection, ProjectileRotation) = projectileParamsSaved;
        }
        
    }
}
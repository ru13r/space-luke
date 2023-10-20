using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class SwipeWeapon: Weapon
    {
        [SerializeField] private float spreadAngle = 30.0f;
        
        protected override IEnumerator BurstRoutine()
        {
            ReadyToShoot = false;
            var projectileParamsSaved = (ProjectileDirection, ProjectileRotation);
            if (stats.Burst == 1)
            {
                base.SingleAttack();
                yield return new WaitForSeconds(1 / stats.FireRate);
            }
            else
            {
                var spreadStep = spreadAngle / (stats.Burst-1);
                for (var i = 0; i < stats.Burst; i++)
                {
                    var rotation = Quaternion.Euler(0f, 0f, -spreadAngle / 2 + i * spreadStep);
                    ProjectileDirection = rotation * projectileParamsSaved.ProjectileDirection;
                    ProjectileRotation = rotation * projectileParamsSaved.ProjectileRotation;
                    base.SingleAttack();
                    yield return new WaitForSeconds(1 / stats.FireRate);
                }
            }
            yield return new WaitForSeconds(stats.BurstReload);
            (ProjectileDirection, ProjectileRotation) = projectileParamsSaved;
            ReadyToShoot = true;
        }
    }
}
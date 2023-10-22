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
            if (weaponStats.Burst == 1)
            {
                base.SingleAttack();
                yield return new WaitForSeconds(1 / weaponStats.FireRate);
            }
            else
            {
                var spreadStep = spreadAngle / (weaponStats.Burst-1);
                for (var i = 0; i < weaponStats.Burst; i++)
                {
                    var rotation = Quaternion.Euler(0f, 0f, -spreadAngle / 2 + i * spreadStep);
                    ProjectileDirection = rotation * projectileParamsSaved.ProjectileDirection;
                    ProjectileRotation = rotation * projectileParamsSaved.ProjectileRotation;
                    base.SingleAttack();
                    yield return new WaitForSeconds(1 / weaponStats.FireRate);
                }
            }
            yield return new WaitForSeconds(weaponStats.BurstReload);
            (ProjectileDirection, ProjectileRotation) = projectileParamsSaved;
            ReadyToShoot = true;
        }
    }
}
using UnityEngine;

namespace Weapons
{
    public class MultiWeapon: Weapon
    {
        [SerializeField] private float spreadDistance = 0.5f;
        
        [Range(2,15)]
        [SerializeField] private int projectileCount = 2;
        protected override void SingleAttack()
        {
            var positionSaved = transform.position;
            var spreadStep = spreadDistance / (projectileCount-1);
            
            for (var i = 0; i < projectileCount; i++)
            {
                transform.position = new Vector3 (-spreadDistance / 2 + i * spreadStep, 0f, 0f);
                base.SingleAttack();
            }

            transform.position = positionSaved;
        }
        
    }
}
using UnityEngine;

namespace WeaponControllers
{
    public class AIShootAtDirection : WeaponController
    {
        [SerializeField] private Vector3 direction = Vector3.down;
        
        private void Update()
        {
            Weapon.SetProjectileDirectionAndRotation(direction, Quaternion.FromToRotation(Vector3.up, direction));
            Weapon.Attack();
        }
    }
}
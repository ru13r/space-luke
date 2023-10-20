using UnityEngine;

namespace Weapons
{
    public interface IWeapon
    {
        public bool IsArmed { get; set; }
        public void Attack();
        public bool IsReady();
        public void SetProjectileDirectionAndRotation(Vector3 direction, Quaternion rotation);
    }
}
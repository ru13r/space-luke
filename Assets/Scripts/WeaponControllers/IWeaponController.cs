using UnityEngine;

namespace WeaponControllers
{
    public interface IWeaponController
    {
        public Vector3 GetAttackVector();
        public Quaternion GetAttackRotation();
    }
}
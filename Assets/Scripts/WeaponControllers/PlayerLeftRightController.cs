using UnityEngine;

namespace WeaponControllers
{
    public class PlayerLeftRightController : WeaponController
    {
        [SerializeField] private float leftAngle = 35f;
        [SerializeField] private float rightAngle = 35f;
        
        private void Update()
        {
            var left = Input.GetKey(KeyCode.Z) ? 1 : 0;;
            var right = Input.GetKey(KeyCode.X) ? 1 : 0;
            if (left == 0 && right == 0) return;
            if (!Weapon.IsReady()) return;
            var attackRotation = Quaternion.Euler(0f, 0f, (left-right) * (left * leftAngle + right * rightAngle));
            Weapon.SetProjectileDirectionAndRotation(attackRotation * Vector3.up, attackRotation);
            Weapon.Attack();
        }
    }
}

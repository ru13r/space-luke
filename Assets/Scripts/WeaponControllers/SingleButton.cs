using UnityEngine;

namespace WeaponControllers
{
    public class SingleButton : WeaponController
    {
        [SerializeField] private KeyCode trigger;

        private void Update()
        {
            var triggerPressed = Input.GetKey(trigger);
            if (!triggerPressed) return;
            if (!Weapon.IsReady()) return;
            Weapon.SetProjectileDirectionAndRotation(Vector3.up, Quaternion.identity);
            Weapon.Attack();
        }
    }
}
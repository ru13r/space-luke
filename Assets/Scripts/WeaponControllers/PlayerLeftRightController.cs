using UnityEngine;
using Weapons;

namespace WeaponControllers
{
    public class PlayerLeftRightController : MonoBehaviour, IWeaponController
    {
        [SerializeField] private GameObject weaponObject;
        [SerializeField] private float leftAngle = 35f;
        [SerializeField] private float rightAngle = 35f;
        
        private IWeapon _weapon;
        private Quaternion _attackRotation;

        private void Awake()
        {
            _weapon = weaponObject.GetComponent<IWeapon>();
        }

        private void Update()
        {
            var left = Input.GetKey(KeyCode.Z) ? 1 : 0;;
            var right = Input.GetKey(KeyCode.X) ? 1 : 0;
            if (left == 0 && right == 0) return;
            _attackRotation = Quaternion.Euler(0f, 0f, (left-right) * (left * leftAngle + right * rightAngle));
            _weapon.Shoot();
        }

        public Vector3 GetAttackVector()
        {
            return _attackRotation * Vector3.up;
        }
        public Quaternion GetAttackRotation()
        {
            return _attackRotation;
        }
    }
}

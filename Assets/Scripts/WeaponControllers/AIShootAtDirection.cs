using UnityEngine;
using Weapons;

namespace WeaponControllers
{
    public class AIShootAtDirection : MonoBehaviour, IWeaponController
    {
        [SerializeField] private Vector3 direction = Vector3.down;
        [SerializeField] private GameObject weaponObject;
        
        private IWeapon _weapon;
        
        private void Awake()
        {
            _weapon = weaponObject.GetComponent<Weapon>();
        }
        private void Update()
        {
            _weapon.Shoot();
        }
        public Vector3 GetAttackVector()
        {
            return direction;
        }
        public Quaternion GetAttackRotation()
        {
            return transform.rotation;
        }
    }
}
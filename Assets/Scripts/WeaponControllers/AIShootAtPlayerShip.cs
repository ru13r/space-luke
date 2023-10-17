using UnityEngine;
using Weapons;

namespace WeaponControllers
{
    public class AIShootAtPlayerShip : MonoBehaviour, IWeaponController
    {
        [SerializeField] private GameObject weaponObject;
        
        private IWeapon _weapon;
        private Ship _playerShip; 
        public void Awake()
        {
            _playerShip = GameObject.Find("Player").GetComponent<Ship>();
            _weapon = weaponObject.GetComponent<Weapon>();
        }
        
        public void Update()
        {
            _weapon.Shoot();
        }
        public Vector3 GetAttackVector()
        {
            var targetPosition = _playerShip.GetCenter();
            return (targetPosition - transform.position).normalized;
        }
        public Quaternion GetAttackRotation()
        {
            return Quaternion.FromToRotation(Vector3.up, GetAttackVector());
        }
    }
}
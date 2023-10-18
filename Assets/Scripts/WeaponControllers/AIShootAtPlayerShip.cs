using UnityEngine;
using Weapons;

namespace WeaponControllers
{
    public class AIShootAtPlayerShip : MonoBehaviour, IWeaponController
    {
        [SerializeField] private GameObject weaponObject;
        
        private IWeapon _weapon;
        private GameObject _player; 
        public void Awake()
        {
            _player = GameObject.Find("Player");
            _weapon = weaponObject.GetComponent<Weapon>();
        }
        
        public void Update()
        {
            _weapon.Shoot();
        }
        public Vector3 GetAttackVector()
        {
            var targetPosition = _player.transform.position;
            return (targetPosition - transform.position).normalized;
        }
        public Quaternion GetAttackRotation()
        {
            return Quaternion.FromToRotation(Vector3.up, GetAttackVector());
        }
    }
}
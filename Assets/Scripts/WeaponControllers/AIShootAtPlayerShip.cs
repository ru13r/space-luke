using UnityEngine;

namespace WeaponControllers
{
    public class AIShootAtPlayerShip : WeaponController
    {
        private GameObject _player; 
        
        public void Start()
        {
            _player = GameObject.Find("Player");
        }
        
        public void Update()
        {
            if (!_player) return;
            var direction = (_player.transform.position - transform.position).normalized;
            var rotation = Quaternion.FromToRotation(Vector3.up, direction);
            Weapon.SetProjectileDirectionAndRotation(direction, rotation);
            Weapon.Attack();
        }
    }
}
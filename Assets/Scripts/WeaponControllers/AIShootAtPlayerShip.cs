using UnityEngine;

namespace WeaponControllers
{
    public class AIShootAtPlayerShip : WeaponController
    {
        private GameObject _player; 
        
        private void Start()
        {
            _player = GameObject.Find("Player");
        }
        
        private void Update()
        {
            if (!_player) return;
            var direction = (_player.transform.position - transform.position).normalized;
            var rotation = Quaternion.FromToRotation(Vector3.up, direction);
            Weapon.SetProjectileDirectionAndRotation(direction, rotation);
            Weapon.Attack();
        }
    }
}
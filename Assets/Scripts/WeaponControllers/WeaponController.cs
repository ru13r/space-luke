using UnityEngine;
using Weapons;

namespace WeaponControllers
{
    public abstract class WeaponController : MonoBehaviour
    {
        [SerializeField] private GameObject weaponObject;
        protected IWeapon Weapon;
        
        public void Arm() => Weapon.IsArmed = true;
        public void Disarm() => Weapon.IsArmed = false;
        
        private void Awake()
        {
            Weapon = weaponObject.GetComponent<Weapon>();
        }
    }
}
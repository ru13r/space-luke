using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class WeaponSystem: MonoBehaviour
    {
        [SerializeField] private List<Weapon> weapons;
        
        public void Arm()
        {
            foreach (var weapon in weapons)
            {
                weapon.Arm();
            }
        }
        public void Disarm()
        {
            foreach (var weapon in weapons)
            {
                weapon.Disarm();
            }
        }
        public void Shoot()
        {
            foreach (var weapon in weapons)
            {
                weapon.Shoot();
            }
        }
    }
}
using UnityEngine;
using WeaponControllers;

namespace Weapons
{
    public class WeaponSystem: MonoBehaviour
    {
        private WeaponController[] _weaponControllers;

        private void Awake()
        {
            _weaponControllers = GetComponents<WeaponController>();
        }

        public void Arm()
        {
            foreach (var wc in _weaponControllers)
            {
                wc.Arm();
            }
        }
        public void Disarm()
        {
            foreach (var wc in _weaponControllers)
            {
                wc.Disarm();
            }
        }
    }
}
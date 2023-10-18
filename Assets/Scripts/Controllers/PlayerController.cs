using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem psDestroyed;
        
        // TODO make health bar
        // TODO show damage on the ship when health bar is low
        private Ship _ship;
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
            // ship
            _ship = gameObject.GetComponent<Ship>();
            _ship.WeaponSystem.Arm();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_ship.GetHealth() <= 0)
            {
                var ps = Instantiate(psDestroyed, transform.position, psDestroyed.transform.rotation);
                Destroy(gameObject);
                ps.Emit(1);
                _gameManager.GameOver();
            }
        
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            var obj = other.gameObject;
            if (obj.layer == LayerMask.NameToLayer("EnemyProjectile"))
            {
                _ship.Damage(obj.GetComponent<ProjectileController>().Damage);
            }
            if (obj.layer == LayerMask.NameToLayer("Enemy"))
            {
                _ship.Damage(Globals.ShipCollisionDamage);
            }
        }
    
  
    }
}

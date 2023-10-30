using System.Collections;
using Managers;
using Stats;
using UnityEngine;
using Weapons;

namespace Controllers
{
    public class ProjectileScript : MonoBehaviour
    {
        private ProjectileStats _stats;
        
        private float _lifetime;

        private Vector3 _direction;
        private float _speed;

        public int Damage => _stats.Damage;

        public void Initialize(string weaponTag, WeaponStats weaponStats, Vector3 direction)
        {
            // set speed, and lifetime
            _stats = weaponStats.ProjectileStats;
            _direction = direction;
            _lifetime = _stats.Range / _stats.Speed;
        
            // set projectile layers
            
            gameObject.layer = weaponTag switch
            {
                "Player" => LayerMask.NameToLayer("PlayerProjectile"),
                _ =>  LayerMask.NameToLayer("EnemyProjectile")
            };
        }
    
        private void Start()
        {
            StartCoroutine(nameof(FiniteLife));
        }

        // projectile is destroyed if it leaves screen
        private void Update()
        {
            if (GameScreen.IsOffScreen(transform.position, new Vector3(0.1f, 0.1f, 0.0f)))
            {
                Destroy(gameObject);
            }
        }

        private void FixedUpdate()
        {
            transform.position += _direction * (Time.deltaTime * _stats.Speed);
        }

        // projectile is destroyed on collision with any object except for projectile
        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }
    
        // projectile has finite life dependent on weapon characteristics
        private IEnumerator FiniteLife()
        {
            yield return new WaitForSeconds(_lifetime);
            Destroy(gameObject);
        }
    }
}

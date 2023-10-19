using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

namespace Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        private float _lifetime;
        private Rigidbody2D _rb;

        private Vector3 _direction;
        private float _speed;

        public int Damage { get; private set; }

        public void Initialize(string projectileTag, WeaponStats stats, Vector3 direction)
        {
            // set speed, and lifetime
            _direction = direction;
            _speed = stats.ProjectileSpeed;
            _lifetime = stats.Range / _speed;
            Damage = stats.Damage;
        
            // set projectile layers
            gameObject.layer = projectileTag switch
            {
                "Player" => LayerMask.NameToLayer("PlayerProjectile"),
                _ =>  LayerMask.NameToLayer("EnemyProjectile")
            };
        }
    
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
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
            _rb.transform.position += _direction * (Time.deltaTime * _speed);
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

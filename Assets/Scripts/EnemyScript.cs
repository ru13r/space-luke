using System.Collections;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    private GameObject _player;
    
    // enemy firing
    private float _fireRate;
    private const float ProjectileSpeed = 4.0f;
    private bool _allowFire;
    public GameObject enemyProjectilePrefab;
    public ParticleSystem psDestroyed;
    private float _initialDelay;
    
    // movement
    private const float Speed = 1.5f;
    private const float KeepDistanceToPlayer = 4.0f;
    private const float KeepDistanceInterval = 0.5f;
    private int _movingDirection;
    
    private HitScript _hitScript;
    private GameManager _gameManager;

    private int _health;

    void Start()
    {
        // resolve other components
        _hitScript = GetComponent<HitScript>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _player = GameObject.Find("Player");  
        
        // initial state
        _allowFire = false;
        _health = 100;

        // randomize shooting and movement
        _initialDelay = Random.Range(2f, 3f);
        _fireRate = Random.Range(0.7f, 1.5f);
        _movingDirection = Random.value > .5f ? 1 : -1;
        Invoke(nameof(StartFiring), _initialDelay);
    }
    
    void Update()
    {
        if (_gameManager.isGameActive)
        {
            MovementRoutine();
            if (_allowFire)
            {
                StartCoroutine(FireProjectile());
            }

            if (_health <= 0)
            {
                var ps = Instantiate(psDestroyed, transform.position, psDestroyed.transform.rotation);
                Destroy(gameObject);
                ps.Emit(1);
                _gameManager.AddScore(1000);
            }
        }
        
    }

    private void MovementRoutine()
    {
        var playerPosition = _player.transform.position;
        var position = transform.position;
        var moveDirection = (playerPosition - position).normalized;
        if (Vector3.Distance(playerPosition, position) >= KeepDistanceToPlayer + KeepDistanceInterval)
        {
            transform.Translate(Speed * Time.deltaTime * moveDirection);
        }
        if (Vector3.Distance(playerPosition, position) <= KeepDistanceToPlayer - KeepDistanceInterval)
        {
            transform.Translate(- Speed * Time.deltaTime * moveDirection);
        }
        else
        {
            var orthogonalDirection = Vector3.Cross(moveDirection, Vector3.forward) * _movingDirection;
            transform.Translate(- Speed * Time.deltaTime * orthogonalDirection);
        }
        // transform.position = _gameManager.MovementClamp(transform.position);
        if (_gameManager.IsOffScreen(gameObject))
        {
            _movingDirection = -_movingDirection;
        }
    }

    private void StartFiring()
    {
        _allowFire = true;
    }
    private IEnumerator FireProjectile()
    {
        _allowFire = false;
        Vector3 fireDirection = (_player.transform.position + _gameManager.vPlayerCenterOffset - transform.position).normalized;
        GameObject projectile = Instantiate(enemyProjectilePrefab, transform.position + fireDirection * 0.3f, transform.rotation);
        // TODO move to EnemyProjectileScript
        projectile.GetComponent<Rigidbody2D>().velocity = (fireDirection * ProjectileSpeed);
        yield return new WaitForSeconds(1 / _fireRate);
        _allowFire = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            // TODO move damage to the projectile class
            _gameManager.AddScore(200);
            _hitScript.HitAnimation();
            _health -= 99;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            _hitScript.HitAnimation();
            _health -= 110;
        }
    }
    
}

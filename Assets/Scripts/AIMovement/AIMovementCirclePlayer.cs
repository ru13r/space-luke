using UnityEngine;

namespace AIMovement
{
    public class AIMovementCirclePlayer : MonoBehaviour
    {
        [SerializeField] private float speed = 1.5f;
        [SerializeField] private float keepDistanceToPlayer = 4.0f;
        [SerializeField] private float keepDistanceInterval = 0.5f;
        
        private GameManager _gameManager;
        private GameObject _player;
        private int _movingDirection;
        private Vector3 _extents;
        
        private void Awake()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            _player = GameObject.Find("Player");
            _extents = gameObject.GetComponent<Collider2D>().bounds.extents;
            _movingDirection = Random.value > .5f ? 1 : -1;
        }

        private void Update()
        {
            if (!_gameManager.isGameActive) return;
            
            var playerPosition = _player.transform.position;
            var position = transform.position;
            var moveDirection = (playerPosition - position).normalized;
            if (Vector3.Distance(playerPosition, position) >= keepDistanceToPlayer + keepDistanceInterval)
            {
                transform.position += speed * Time.deltaTime * moveDirection;
            }
            if (Vector3.Distance(playerPosition, position) <= keepDistanceToPlayer - keepDistanceInterval)
            {
                transform.position -= speed * Time.deltaTime * moveDirection;
            }
            else
            {
                var orthogonalDirection = Vector3.Cross(moveDirection, Vector3.forward) * _movingDirection;
                transform.position -=  speed * Time.deltaTime * orthogonalDirection;
            }
            if (GameScreen.IsOffScreen(transform.position, -_extents))
            {
                _movingDirection = -_movingDirection;
            }
        }
    }
}
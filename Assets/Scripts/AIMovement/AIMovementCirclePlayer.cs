using UnityEngine;
using Random = UnityEngine.Random;

namespace AIMovement
{
    public class AIMovementCirclePlayer : MonoBehaviour
    {
        [SerializeField] private float speed = 1.5f;
        [SerializeField] private float keepDistanceToPlayer = 4.0f;
        [SerializeField] private float keepDistanceInterval = 0.5f;
        
        private ScreenManager _screenManager;
        private GameManager _gameManager;
        private GameObject _player;
        private int _movingDirection;
        private (float, float) _dimensions;
        
        private void Awake()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            _screenManager = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
            _player = GameObject.Find("Player");
            _dimensions = GetComponent<Ship>().GetDimensions();
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
                transform.Translate(speed * Time.deltaTime * moveDirection);
            }
            if (Vector3.Distance(playerPosition, position) <= keepDistanceToPlayer - keepDistanceInterval)
            {
                transform.Translate(- speed * Time.deltaTime * moveDirection);
            }
            else
            {
                var orthogonalDirection = Vector3.Cross(moveDirection, Vector3.forward) * _movingDirection;
                transform.Translate(- speed * Time.deltaTime * orthogonalDirection);
            }
            if (_screenManager.MovementClamp(transform.position, _dimensions) != transform.position)
            {
                _movingDirection = -_movingDirection;
            }
        }
    }
}
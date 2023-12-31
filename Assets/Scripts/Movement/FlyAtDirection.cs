using Managers;
using UnityEngine;

namespace AIMovement
{
    public class FlyAtDirection : MonoBehaviour
    {
        [SerializeField] private float speed = 1.5f;
        [SerializeField] private Vector3 direction;
        
        private GameManager _gameManager;
        private void Awake()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void Update()
        {
            if (!_gameManager.IsGameActive) return;
            {
                transform.position += speed * Time.deltaTime * direction.normalized;
                if (transform.position.y <= -10f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
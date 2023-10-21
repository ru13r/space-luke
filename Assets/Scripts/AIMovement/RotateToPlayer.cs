using System;
using UnityEngine;

namespace AIMovement
{
    public class RotateToPlayer : MonoBehaviour
    {
        [SerializeField] private float turnRate = 45f; // degrees per second
        
        private GameManager _gameManager;
        private GameObject _player;

        private void Awake()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            _player = GameObject.Find("Player");
        }
        
        private void Update()
        {
            if (!_gameManager.isGameActive) return;
            if (!_player) return;
            
            var myTransform = transform;
            var towardsPlayer = (_player.transform.position - myTransform.position).normalized;
            var lookDirection = myTransform.up;
            var angle = Vector3.SignedAngle(lookDirection, towardsPlayer, Vector3.forward);
            if (Mathf.Abs(angle) > 0f)
            {
                transform.Rotate(Vector3.forward, Mathf.Sign(angle) * turnRate * Time.deltaTime );
            }

        }
        
    }
}
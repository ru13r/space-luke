using UnityEngine;

namespace Background
{
    public class ParallaxBackground : MonoBehaviour
    {
        private Vector3 _position;
        private GameObject _player;
        private void Awake()
        {
            _position = transform.position;
            _player = GameObject.Find("Player");

        }

        private void LateUpdate()
        {
            var playerPosition = _player.transform.position;
            transform.position = _position + new Vector3(- playerPosition.x / 10, 0);
        }
    }
}
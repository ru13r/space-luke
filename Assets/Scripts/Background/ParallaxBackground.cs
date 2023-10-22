using System;
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

        private void Start()
        {
            var transform1 = transform;
            var position = transform1.position;
            transform1.position = new Vector3(position.x, position.y, Globals.BackgroundZOrder);
        }

        private void LateUpdate()
        {
            if (!_player) return;
            var playerPosition = _player.transform.position;
            transform.position = _position + new Vector3(- playerPosition.x / 10f, 0f, 0f);
        }
    }
}
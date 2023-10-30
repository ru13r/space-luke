using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class SpawnManager : MonoBehaviour
    {
        public List<GameObject> enemyPrefabs;
        private GameObject _player;
        private GameManager _gameManager;
    
        // Start is called before the first frame update
        void Start()
        {
            _player = GameObject.Find("Player");
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && _gameManager.IsGameActive)
            {
                SpawnWave(_gameManager.WaveCounter);
            }
        
        }
        private void SpawnWave(int count)
        {
            if (enemyPrefabs.Count == 0)
            {
                throw new Exception("Prefabs list in spawn manager is empty!");
            }
            // TODO move up to settings
            var minDistance = 1.5f;
            var list = new List<Vector3>();
            var n = 1;
            // TODO not enough room to spawn more than 17 enemies
            count = count <= 15 ? count : 15;
            while (n <= count)
            {
                var newSpawnPoint = GameScreen.GenerateRandomSpawnPoint(new Vector3(-0.5f, 0f, 0f));
                if (list
                        .ConvertAll(spawnPoint => Vector3.Distance(spawnPoint, newSpawnPoint))
                        .All(distance => distance > minDistance)
                    && Vector3.Distance(newSpawnPoint, _player.transform.position) > minDistance)
                {
                    list.Add(newSpawnPoint);
                    n++;
                }            
            }
            foreach (var spawnPoint in list)
            {
                var prefab = enemyPrefabs[Random.Range(0,enemyPrefabs.Count)];
                Instantiate(prefab, spawnPoint, prefab.transform.rotation);      
            }
            _gameManager.WaveCounter++;

        }
    }
}

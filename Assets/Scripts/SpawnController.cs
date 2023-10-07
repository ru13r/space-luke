using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
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
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            SpawnWave(_gameManager.WaveCounter);
        }
        
    }
    private void SpawnWave(int count)
    {
        // TODO move up to settings
        var minDistance = 2.0f;
        var list = new List<Vector3>();
        var n = 1;
        // TODO not enough room to spawn more than 17 enemies
        count = count <= 17 ? count : 17;
        while (n <= count)
        {
            var newSpawnPoint = _gameManager.GenerateRandomSpawnPoint();
            if (list
                .ConvertAll(spawnPoint => Vector3.Distance(spawnPoint, newSpawnPoint))
                .All(distance => distance > minDistance)
                && Vector3.Distance(newSpawnPoint, _player.transform.position) > minDistance)
            {
                list.Add(newSpawnPoint);
                n++;
            }            
        }
        list.ForEach(spawnPoint  => Instantiate(enemyPrefab, spawnPoint, enemyPrefab.transform.rotation ));
        _gameManager.WaveCounter++;

    }
}

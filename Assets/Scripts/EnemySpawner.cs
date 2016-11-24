using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    float spawnTimer = 5f;


    //void Start()
    //{
    //    StartSpawning();
    //}

    void OnEnable()
    {
        EventManager.onStartGame += StartSpawning;
    }

    void OnDisable()
    {
        StopSpawning();
        EventManager.onStartGame -= StartSpawning;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
    }

    void StopSpawning()
    {
        CancelInvoke();
    }
}

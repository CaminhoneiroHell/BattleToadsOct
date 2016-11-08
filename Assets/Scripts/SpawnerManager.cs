using UnityEngine;
using System.Collections;

public class SpawnerManager : MonoBehaviour {

    public bool canSpawn = true;
    public float spawnTime = 5f;
    public float spawnDelay = 3f;
    public GameObject wave;

    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }


    void Spawn()
    {
        //int enemyIndex = Random.Range(0, wave.Length);
        if(canSpawn)
        Instantiate(wave, transform.position, transform.rotation);
    }
}

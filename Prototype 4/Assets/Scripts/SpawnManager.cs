using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9f;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount;
    public int waveNumber;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWaive(waveNumber);
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWaive(waveNumber);
            Instantiate(powerupPrefab, SpawnRandomPosition(), Quaternion.identity);
        }
    }

    private Vector3 SpawnRandomPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomSpawn = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomSpawn;
    }

    void SpawnEnemyWaive(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, SpawnRandomPosition(), enemyPrefab.transform.rotation);
        }
    }
}

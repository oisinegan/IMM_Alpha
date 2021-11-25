using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject healthPowerup;
    public GameObject speedPowerup;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber;

    // Start is called before the first frame update
    void Start(){ }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0 && GameManager.isGameActive)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            if (waveNumber % 3 == 0)
            { 
                Instantiate(speedPowerup, GenerateSpawnPosition(), speedPowerup.transform.rotation);
            }
            if (waveNumber % 4 == 0 && GameManager.isGameActive)
            {
                Instantiate(healthPowerup, GenerateSpawnPosition(), speedPowerup.transform.rotation);
            }
        }
    }

    void SpawnEnemyWave(int enemy)
    {
        for(int i = 0; i < enemy; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosition = new Vector3(spawnPositionX, 1.05f, spawnPositionZ);
        return randomPosition;
    }
}

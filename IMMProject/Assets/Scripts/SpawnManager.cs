using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosition = new Vector3(spawnPositionX, 1.05f, spawnPositionZ);
        Instantiate(enemyPrefab, randomPosition, enemyPrefab.transform.rotation);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

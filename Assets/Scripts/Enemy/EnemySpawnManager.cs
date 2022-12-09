using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private float SpawnDelay;
    [SerializeField] private float SpawnRate = 3;
    [SerializeField] private GameObject EnemyPrefab;
    private int randomSpawnZone;
    private float SpawnPositionX, SpawnPositionY;

    void Start()
    {
        StartCoroutine(EnemySpawn(SpawnDelay));
    }

    IEnumerator EnemySpawn(float FirstDelay)
    {
        float spawnCountdown = FirstDelay;
        float spawnRateCountdown = SpawnRate;
        while (true)
        {
            yield return null;
            spawnCountdown -= Time.deltaTime;
            spawnRateCountdown -= Time.deltaTime;

            randomSpawnZone = Random.Range(-1, 4);

            switch (randomSpawnZone)
            {
                case 0:
                    SpawnPositionX = Random.Range(-17f, 17f);
                    SpawnPositionY = Random.Range(12f, 9f);
                    break;
                case 1:
                    SpawnPositionX = Random.Range(16f, 20f);
                    SpawnPositionY = Random.Range(-9f, 9f);
                    break;
                case 2:
                    SpawnPositionX = Random.Range(-17f, 17f);
                    SpawnPositionY = Random.Range(-9f, -12f);
                    break;
                case 3:
                    SpawnPositionX = Random.Range(-20f, -16f);
                    SpawnPositionY = Random.Range(9f, -9f);
                    break;
            }

            if (spawnRateCountdown < 0 && SpawnDelay > 0.1)
            {
                spawnRateCountdown += SpawnRate;
                SpawnDelay -= 0.05f;
            }

            if (spawnCountdown < 0)
            {
                spawnCountdown += SpawnDelay;
                Instantiate(EnemyPrefab, new Vector3(SpawnPositionX, SpawnPositionY), Quaternion.identity);
            }
        }
        
    }
}

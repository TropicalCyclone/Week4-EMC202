using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private float SpawnDelay;
    [SerializeField] private GameObject EnemyPrefab;
    private int randomSpawnZone;
    private float SpawnPositionX, SpawnPositionY;

    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
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
            Instantiate(EnemyPrefab, new Vector3(SpawnPositionX, SpawnPositionY), Quaternion.identity);
            yield return new WaitForSeconds(SpawnDelay);
        }
        
    }
}

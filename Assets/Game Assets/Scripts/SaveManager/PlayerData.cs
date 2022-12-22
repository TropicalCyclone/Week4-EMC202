using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
        public float HitPoints;
        public float enemySpawnDelay;
        public string playerID;
        public float[] position;

    public PlayerData(PlayerController player,EnemySpawnManager spawnManager,ScoreManager score)
    {
        HitPoints = player.HitPoints;
        playerID = PlayerPrefs.GetString("player_class");
        enemySpawnDelay = spawnManager.SpawnDelay;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

    public PlayerData()
    { 
        HitPoints = 5;
        playerID = "0001";
        enemySpawnDelay = 3;
    }
}

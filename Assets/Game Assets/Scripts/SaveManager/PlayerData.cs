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
    public int Score;
    public bool[] Achievements;

    public PlayerData(PlayerController player,EnemySpawnManager spawnManager,ScoreManager score,AchievementSystem achievementSystem)
    {
        HitPoints = player.HitPoints;
        playerID = PlayerPrefs.GetString("player_class");
        enemySpawnDelay = spawnManager.SpawnDelay;
        position = new float[3];
        Score = PlayerPrefs.GetInt("Score");
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        Achievements = new bool[achievementSystem.achievement.Count];
        Achievements[0] = achievementSystem.achievement[0].isCompleted;
        Achievements[1] = achievementSystem.achievement[1].isCompleted;
    }

    public PlayerData()
    { 
        HitPoints = 5;
        playerID = "0001";
        enemySpawnDelay = 3;
        position = new float[3];
        position[0] = 0;
        position[1] = 0;
        position[2] = 0;
    }
}

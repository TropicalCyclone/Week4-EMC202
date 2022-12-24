using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    public PlayerData _localPlayerData;

    private const string SAVE_DATA_KEY = "playerData";

    public void Save(PlayerController player, EnemySpawnManager spawnManager, ScoreManager score,AchievementSystem achievement)
    {
        _localPlayerData = new PlayerData(player, spawnManager, score, achievement);
        _playerData.playerID = _localPlayerData.playerID;
        var playerData = JsonConvert.SerializeObject(_localPlayerData);
        PlayerPrefs.SetString(SAVE_DATA_KEY, playerData);
       

        Debug.Log(playerData);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(SAVE_DATA_KEY))
        {
            var jsonToConvert = PlayerPrefs.GetString(SAVE_DATA_KEY); 
            _localPlayerData = JsonConvert.DeserializeObject<PlayerData>(jsonToConvert);
        }
        else
        {
            var playerData = new PlayerData();
            var data = JsonConvert.SerializeObject(playerData);
            PlayerPrefs.SetString(SAVE_DATA_KEY, data);
        }
    }
}

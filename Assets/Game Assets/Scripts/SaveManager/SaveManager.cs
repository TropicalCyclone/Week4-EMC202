using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    private PlayerData _localPlayerData;

    private const string SAVE_DATA_KEY = "playerData";

    public void Save(PlayerController player, EnemySpawnManager spawnManager, ScoreManager score)
    {
        _localPlayerData = new PlayerData(player, spawnManager, score);
        _playerData.playerID = _localPlayerData.playerID;
        var playerData = JsonConvert.SerializeObject(_localPlayerData);
        PlayerPrefs.SetString(SAVE_DATA_KEY, playerData);
       

        Debug.Log(playerData);
    }

    private void Load()
    {

    }
}

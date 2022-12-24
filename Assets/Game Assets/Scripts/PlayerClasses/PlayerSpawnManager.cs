using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private PlayerClassDatabase playerClassDatabase;
    private GameObject CurrentPlayer;
    private GameObject Player;
    public ScoreManager score;
    public SaveManager saveManager;
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("Continue") == 0)
        {
            PlayerPrefs.SetInt("Score", 0);
            CurrentPlayer = GetPlayerModel(PlayerPrefs.GetString("player_class")).PlayerModel;
            if (CurrentPlayer != null && CurrentPlayer != Player)
            {
                Instantiate(CurrentPlayer, transform.position, transform.rotation);
                GameObject Player = GetPlayerModel(PlayerPrefs.GetString("player_class")).PlayerModel;
            }
            else
            {
                CurrentPlayer.SetActive(true);
            }
        }
        else
        {
            saveManager.Load();
            CurrentPlayer = GetPlayerModel(saveManager._localPlayerData.playerID).PlayerModel;
            PlayerPrefs.SetFloat("player_HP", saveManager._localPlayerData.HitPoints);
            PlayerPrefs.SetInt("Score", saveManager._localPlayerData.Score);

            if (CurrentPlayer != null && CurrentPlayer != Player)
            {
                Instantiate(CurrentPlayer, new Vector3(saveManager._localPlayerData.position[0], saveManager._localPlayerData.position[1], saveManager._localPlayerData.position[2]), transform.rotation);
                GameObject Player = GetPlayerModel(PlayerPrefs.GetString("player_class")).PlayerModel;
            }
            else
            {
                CurrentPlayer.SetActive(true);
            }
        }
        
    }

    // Start is called before the first frame update
    public PlayerClass GetPlayerModel(string ID)
    {
        foreach(PlayerClass Player in playerClassDatabase.allClasses)
        {
            PlayerClass item = Player;
            if (item.classID == ID)
            {
                PlayerPrefs.SetFloat("player_HP", Player.HP);
                return item;
            }
        }
        PlayerPrefs.SetFloat("player_HP", 10);
        return GetPlayerModel("0001");
    }
}

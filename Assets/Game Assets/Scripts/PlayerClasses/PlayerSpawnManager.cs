using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private PlayerClassDatabase playerClassDatabase;
    private GameObject CurrentPlayer;
    private GameObject Player;
    public ScoreManager score;
    private void OnEnable()
    {
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

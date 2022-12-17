using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private PlayerClassDatabase playerClassDatabase;
    private GameObject CurrentPlayer;
    private GameObject Player;

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
        for (int i = 0; i < playerClassDatabase.allClasses.Count; i++)
        {
            PlayerPrefs.SetFloat("player_HP", playerClassDatabase.allClasses[i].HP);
            PlayerClass item = playerClassDatabase.allClasses[i];
            if (item.classID == ID)
                return item;
        }
        PlayerPrefs.SetFloat("player_HP", 10);
        return GetPlayerModel("0001");
    }
}

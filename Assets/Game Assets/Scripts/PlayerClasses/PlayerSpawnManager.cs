using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private PlayerClassDatabase playerClassDatabase;
    
    private void Awake()
    { 
        Instantiate(SpawnPlayerClass(PlayerPrefs.GetString("player_class")).PlayerModel, transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    public PlayerClass SpawnPlayerClass(string ID)
    {
        for (int i = 0; i < playerClassDatabase.allClasses.Count; i++)
        {
            PlayerPrefs.SetFloat("player_HP", playerClassDatabase.allClasses[i].HP);
            PlayerClass item = playerClassDatabase.allClasses[i];
            if (item.classID == ID)
                return item;
        }
        PlayerPrefs.SetFloat("player_HP", 10);
        return SpawnPlayerClass("0001");
    }
}

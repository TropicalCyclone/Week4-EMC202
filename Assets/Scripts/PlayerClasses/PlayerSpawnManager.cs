using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private PlayerClassDatabase playerClassDatabase;

    private void Start()
    {
        PlayerClass playerclass = GetPlayerClass("0001");
        if(playerclass != null)
        Instantiate(playerclass);
    }

    // Start is called before the first frame update
    public PlayerClass GetPlayerClass(string ID)
    {
        foreach (PlayerClass item in playerClassDatabase.allClasses)
        {
            if (item.classID == ID)
                return item;
        }
        return null;
    }
}

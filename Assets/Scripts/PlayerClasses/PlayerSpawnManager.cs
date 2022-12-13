using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private PlayerClassDatabase playerClassDatabase;
    

    private void Start()
    { 
        Instantiate(GetPlayerClass("").PlayerModel, transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    public PlayerClass GetPlayerClass(string ID)
    {
        for (int i = 0; i < playerClassDatabase.allClasses.Count; i++)
        {
            PlayerClass item = playerClassDatabase.allClasses[i];
            if (item.classID == ID)
                return item;
        }
        return GetPlayerClass("0001");
    }
}

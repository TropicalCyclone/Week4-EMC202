using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private PlayerClassDatabase playerClassDatabase;
    private string classID = "";

    private void Start()
    { 
        Instantiate(SpawnPlayerClass(classID).PlayerModel, transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    public PlayerClass SpawnPlayerClass(string ID)
    {
        for (int i = 0; i < playerClassDatabase.allClasses.Count; i++)
        {
            PlayerClass item = playerClassDatabase.allClasses[i];
            if (item.classID == ID)
                return item;
        }
        return SpawnPlayerClass("0001");
    }

    public void SetPlayerClass(string ID)
    {
        classID = ID;   
    }
}

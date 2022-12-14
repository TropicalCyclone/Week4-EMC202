using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new PLayer Class", menuName = "Player/Class")]
public class PlayerClass : ScriptableObject
{
    
    [SerializeField] public string classID;
    [SerializeField] public string className;
    [SerializeField] public float HP;
    public GameObject PlayerModel;
    [TextArea(10, 10)]
    public string itemDesc;

}

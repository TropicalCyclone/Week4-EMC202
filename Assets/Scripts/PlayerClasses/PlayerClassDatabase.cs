using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerDatabase", menuName = "Assets/Databases/Class Database")]
public class PlayerClassDatabase : ScriptableObject
{
    public List<PlayerClass> allClasses;
}

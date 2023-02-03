using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnnemyData", menuName = "Tower Defense/Ennemy Data")]
public class EnnemyData : ScriptableObject
{
    public string ennemyName;
    [Range(0,1000)] public int Health;
    [Range(0,1000)] public float speed;
    [Range(0,1000)] public int moneyDrop;
    public GameObject ennemyModel;
}

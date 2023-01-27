using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnnemyData", menuName = "Tower Defense/Ennemy Data")]
public class EnnemyData : ScriptableObject
{
    public string ennemyName;
    public int Health;
    public float speed;
    public int moneyDrop;
    public GameObject ennemyModel;
}

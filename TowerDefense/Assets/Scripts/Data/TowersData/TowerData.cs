using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Tower Defense/TowerData")]
public class TowerData : ScriptableObject
{
    public string towerName;
    public int upgradeCost;
    public int price;
    public float dmg;
    public float attkSpeed;
    public string elementType1;
    public string elementType2;
    public Vector2 range;
    public GameObject towerModel;
    //public upgrades
}

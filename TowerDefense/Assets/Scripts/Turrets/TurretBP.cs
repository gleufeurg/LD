using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.Editor;
using UnityEngine;

[System.Serializable]
public class TurretBP
{
    public GameObject prefab;
    public GameObject upgradedPrefab;
    //[Range(0, 10)] public float sellPrct;
    public int cost;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}

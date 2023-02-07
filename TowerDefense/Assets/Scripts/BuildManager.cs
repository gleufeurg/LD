using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Il y a déjà un BuildManager dans la scene !");
        }
        Instance = this;
    }
    #endregion


    [Space(25f)]
    [Header("References")]

    private GameObject turretToBuild;
    public GameObject standardTurretPrefab;

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    public GameObject getTurretToBuild()
    {
        return turretToBuild; 
    }
}

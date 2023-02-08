using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il y a déjà un BuildManager dans la scene !");
        }
        instance = this;
    }
    #endregion

    [Space(25f)]
    [Header("References")]

    private TurretBP turretToBuild;
    public GameObject standardTurretPrefab;
    public GameObject rocketLauncherPrefab;
    public bool canBuild { get { return turretToBuild != null; } }


    public void SelectTurretToBuild(TurretBP turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Pas assez d'argent");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Excellent acchat, il vous reste : " + PlayerStats.money);
    }
}

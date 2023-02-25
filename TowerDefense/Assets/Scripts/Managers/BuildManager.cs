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

    public TurretBP turretToBuild;
    public GameObject buildEffect;
    public NodeUI nodeUI;
    private Node selectedNode;

    public bool canBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }


    public TurretBP GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectTurret(TurretBP turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    
    public void SelectNode(Node node)
    {
        
        if(node == selectedNode)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}

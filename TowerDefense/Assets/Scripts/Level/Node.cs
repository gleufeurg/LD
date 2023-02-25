using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Space(25f)]
    [Header("References")]

    public GameObject turretGO;
    private Renderer rend;
    private BuildManager buildManager;
    public GameObject turret;
    public TurretBP turretBP;
    public bool isUpgraded = false;

    [Space(25f)]
    [Header("Others")]

    public Vector3 positionOffset;
    public Color hoverColor;
    private Color startColor;
    [SerializeField] private Color cannotBuildColor;


    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBP.upgradeCost)
        {
            //Debug.Log("Pas assez d'argent pour améliorer ce machin sergent");
            return;
        }

        PlayerStats.money -= turretBP.upgradeCost;
        //Destruction de l'ancienne tourelle
        Destroy(turretGO);

        //Instantiate la nouvelle tourelle améliorée
        GameObject _turret = (GameObject)Instantiate(turretBP.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turretGO = _turret;
        //Debug.Log(node.GetBuildPosition());

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isUpgraded = true;

        //Debug.Log("Excellente amélioration ! Il vous reste : " + PlayerStats.money);
        //Debug.Log(node.GetBuildPosition());
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBP.GetSellAmount();

        /* Spawn effect */

        Destroy(turretGO);
        turretBP = null;
        isUpgraded = false;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void BuildTurret(TurretBP _turretBP)
    {
         if (PlayerStats.money < _turretBP.cost)
         {
             //Debug.Log("Alors ! Pas assez d'argent pour contruire ?");
             return;
         }

         PlayerStats.money -= _turretBP.cost;

        turretBP = _turretBP;

         GameObject _turret = (GameObject)Instantiate(turretBP.prefab, GetBuildPosition(), Quaternion.identity);
         turretGO = _turret;
         //Debug.Log(node.GetBuildPosition());

         GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
         Destroy(effect, 1f);

         //Debug.Log("Excellent achat, il vous reste : " + PlayerStats.money);
         //Debug.Log(node.GetBuildPosition());
    }

    private void OnMouseDown()
    {
        //Quand la souris est sur un élément d'UI, ne construit rien sur la Node en dessous
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        //Une tourelle est déjà sur la case, ne construit rien
        if (turretGO != null)
        {
            //Debug.Log("Foutu capitalistes et leur propriété privé, heureusement on peut encore améliorer cette case à défaut de ne plus pouvoire construire dessus");
            buildManager.SelectNode(this);
            return;
        }

        //Si aucune tourelle n'est sélectionnée return
        if (!buildManager.canBuild)
            return;

        //Build selected turret
        BuildTurret(buildManager.GetTurretToBuild());
    }

    private void OnMouseEnter()
    {
        //Quand la souris est sur un élément d'UI, ne construit rien sur la Node en dessous
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // si pas asser d'argent on affiche la NODE en ROUGE (couleur choisie dans la prefabs NODE)
        if (!buildManager.hasMoney || turretGO != null)
        {
            rend.material.color = cannotBuildColor;
            return;
        }

        //Highlight la color où la souris se situe
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        //Rend l'ancienne couleur de la Node quand la souris n'est plus dessus
        rend.material.color = startColor;
    }
}

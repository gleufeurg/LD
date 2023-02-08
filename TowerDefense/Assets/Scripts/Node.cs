using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Space(25f)]
    [Header("References")]

    public GameObject turret;
    private Renderer rend;
    private BuildManager buildManager;

    [Space(25f)]
    [Header("Stats")]

    public Vector3 positionOffset;

    [Space(25f)]
    [Header("Stats")]

    public Color hoverColor;
    private Color startColor;


    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        //Quand la souris est sur un élément d'UI, ne construit rien sur la Node en dessous
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //Si aucune tourelle n'est sélectionnée return
        if (!buildManager.canBuild)
            return;

        //Une tourelle est déjà sur la case, ne construit rien
        if (turret != null)
        {
            //Debug.Log("Foutu capitalistes et leur propriété privé");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        //Quand la souris est sur un élément d'UI, ne construit rien sur la Node en dessous
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //Highlight la color où la souris se situe
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        //Rend l'ancienne couleur de la Node quand la souris n'est plus dessus
        rend.material.color = startColor;
    }
}

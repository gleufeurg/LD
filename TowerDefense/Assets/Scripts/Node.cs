using UnityEngine;

public class Node : MonoBehaviour
{
    [Space(25f)]
    [Header("References")]

    private Renderer rend;
    private GameObject turret;

    [Space(25f)]
    [Header("Stats")]

    public Vector3 positionOffset;

    [Space(25f)]
    [Header("Stats")]

    public Color hoverColor;
    private Color startColor;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Foutu capitalisme et leur propriété privé");
            return;
        }

        GameObject turretToBuild = BuildManager.Instance.getTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

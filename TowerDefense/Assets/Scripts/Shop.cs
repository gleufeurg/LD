using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBP standardTurret;
    public TurretBP rocketLauncherTurret;
    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void SelectStandardTurret()
    {
        //Debug.Log("Prenez votre tourelle de TEST commandant");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectRocketLauncherTurret()
    {
        //Debug.Log("Prenez votre Lance missile commandant");
        buildManager.SelectTurretToBuild(rocketLauncherTurret);
    }
}

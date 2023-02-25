using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBP standardTurret;
    public TurretBP rocketLauncherTurret;
    public TurretBP laserBeamTurret;
    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void SelectStandardTurret()
    {
        //Debug.Log("Prenez votre tourelle de TEST commandant");
        buildManager.SelectTurret(standardTurret);
    }
    public void SelectRocketLauncherTurret()
    {
        //Debug.Log("Prenez votre Lance missile commandant");
        buildManager.SelectTurret(rocketLauncherTurret);
    }
    
    public void SelectLaserBeamTurret()
    {
        //Debug.Log("LASEEEEEEEEEEERRRRR !!!!");
        buildManager.SelectTurret(laserBeamTurret);
    }
}

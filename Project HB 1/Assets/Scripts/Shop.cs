
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserTurret;


    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret() 
    {
        Debug.Log("turret selected");
        buildManager.SelectTurretToBuild(standardTurret);
    
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("missile launcher selected");
        buildManager.SelectTurretToBuild(missileLauncher);

    }

    public void SelectLaserTurret()
    {
        Debug.Log("Laser beam turret selected");
        buildManager.SelectTurretToBuild(laserTurret);

    }
}

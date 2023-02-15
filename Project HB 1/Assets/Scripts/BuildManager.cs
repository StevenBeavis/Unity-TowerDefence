using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //personal
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one build manager");
        
        }
        instance = this;
    }

    private TurretBlueprint turretToBuild;

    private GrassNode selectedN;

    public TurretUI TurretUI;

    public bool HasMoney { get { return PlayerStats.Money>=turretToBuild.cost; } }
    public bool CanBuild { get { return turretToBuild != null;  } }

    

    public void SelectNode(GrassNode node)
    {
        if (selectedN == node)
        {
            DeselectTurret();
            return;
        }
        selectedN = node;
        turretToBuild = null;

        TurretUI.SetTarget(node);
    }

    public void DeselectTurret()
    {
        selectedN = null;

        TurretUI.Hide();

    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectTurret();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}

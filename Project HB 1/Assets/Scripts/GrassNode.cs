using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GrassNode : MonoBehaviour
{
    //mixture of personal written code and various tutorials
    public Color hoverColor;
    public Vector3 positionOffset;
    public Color NoMoneyColor;

    [Header ("Optional Turret")]
    public GameObject turret;
    public TurretBlueprint turretBlueprint;
    public bool isUpgraded = false;

    public GameObject buildEffect;
    public GameObject sellEffect;

    private Renderer rend;

    private Color StartColor;

    BuildManager buildManager;

    

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    { return transform.position + positionOffset; }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        
        if (turret !=null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildOn(buildManager.GetTurretToBuild()); 
    }

    void BuildOn(TurretBlueprint blue)
    {
        if (PlayerStats.Money < blue.cost)
        {
            Debug.Log("No Money");
            return;
        }
        PlayerStats.Money -= blue.cost;
        GameObject _turret = (GameObject)Instantiate(blue.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blue;


        GameObject effect = (GameObject)Instantiate(buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build, money left" + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("No Money to upgrade");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("turret upgraded,money left " + PlayerStats.Money);
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.SellAmount();

        GameObject effect = (GameObject)Instantiate(sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;

        rend.material.color = hoverColor;
        if (turret != null || !buildManager.HasMoney)
            rend.material.color = NoMoneyColor;

    }


    void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
}

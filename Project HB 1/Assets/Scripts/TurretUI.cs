using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    //used UI tutorial from Brackeys
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellCost;

    private GrassNode target;

    public void SetTarget(GrassNode _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "£" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
}
        else 
        {
            upgradeCost.text = "Max Level";
            upgradeButton.interactable = false;
        }

        sellCost.text = "£" + target.turretBlueprint.SellAmount();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectTurret();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectTurret();
    }
}

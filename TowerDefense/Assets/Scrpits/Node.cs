using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private Color startColor;
    public Color hoverColor;
    public Color insufficientEnergyColor;

    //[Header("Optional")] -- works as a header so it doesnt show in inspector but can still be public
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;


    private Renderer rend;

    public Vector3 positionOffset;

    BuildManager buildManager;



    void Start()
    {
        rend = GetComponent<Renderer>();

        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Energy < blueprint.cost)
        {
            Debug.Log("Insufficient Energy!");
            return;
        }

        PlayerStats.Energy -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret Built!");
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Energy < turretBlueprint.upgradeCost)
        {
            Debug.Log("Insufficient Energy!");
            return;
        }

        PlayerStats.Energy -= turretBlueprint.upgradeCost;

        //getting rid of old turret
        Destroy(turret);

        //Building upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret Upgraded!");
    }

   public void SellTurret()
    {
        PlayerStats.Energy += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
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
        if (buildManager.HasEnergy)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = insufficientEnergyColor;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

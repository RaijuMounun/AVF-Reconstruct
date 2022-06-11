using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Materiall", fileName = ("New Materiall"))]
public class SO_MaterialUI : ScriptableObject
{
    public float stock;

    [FoldoutGroup("Production Bools")]
    public bool isProduction, isManagerBought, isBuildingBought;

    [FoldoutGroup("Timers And Times")]
    public float timer, time;

    [FoldoutGroup("Upgrade")]
    public float MaterialCost, SpdUpgCost, IncUpgCost, BuildingCost, ManagerCost, SpdUpgLvl, IncUpgLvl, SpdUpgMultiplier, IncUpgMultiplier, SpdUpgCostMultiplier, IncUpgCostMultiplier;
    

    public void SellMaterial()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().money += (stock * MaterialCost); //I couldn't find it with name IDK why, Scriptable object doesn't hold when you drag and drop things, and at last I did this.
        stock = 0;
    }

    public void SpeedUpgrade()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().money >= SpdUpgCost)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().money -= SpdUpgCost;
            SpdUpgLvl += 1;
            SpdUpgCost *= SpdUpgCostMultiplier;
            if (SpdUpgLvl % 10 == 0)
                time /= (SpdUpgMultiplier*2); //Twice as fast at multiples of 10
            else
                time /= SpdUpgMultiplier;
        }
    }
    //Speed and income upgrades are doing the same job but IDK how to call a function with parameters in button, so I did it this way.
    public void IncomeUpgrade()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().money >= IncUpgCost)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().money -= IncUpgCost;
            IncUpgLvl += 1;
            IncUpgCost *= IncUpgCostMultiplier;
            MaterialCost *= IncUpgMultiplier;
        }
    }

    public void BuyManager()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().money >= ManagerCost)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().money -= ManagerCost;
            isManagerBought = true;
        }
    }
    //These two are doing the same job as well, but like I said, IDK. I think I can do this by events but IDK about events.
    public void BuyBuilding()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().money >= BuildingCost)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().money -= BuildingCost;
            isBuildingBought = true;
        }
    }

}

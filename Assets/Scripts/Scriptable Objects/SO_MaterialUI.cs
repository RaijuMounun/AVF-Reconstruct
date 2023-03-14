using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using TMPro;

[CreateAssetMenu(menuName = "Materiall", fileName = ("New Materiall"))]
public class SO_MaterialUI : ScriptableObject
{
    #region Properties
    public float Money
    {
        get
        {
            return GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().money;
        }
        set
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().money = value;
        }
    }

    public TMP_Text SpdUpgCostText
    {
        get
        {
            return GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().SpdUpgCostTextsArray[order];
        }
        set
        {
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().SpdUpgCostTextsArray[order] = value;
        }
    }


    public TMP_Text IncUpgCostText
    {
        get
        {
            return GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().IncUpgCostTextsArray[order];
        }
        set
        {
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().IncUpgCostTextsArray[order] = value;
        }
    }


    public GameObject ManagerSubMenu
    {
        get
        {
            return GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().managerSubMenusArray[order];
        }
        set
        {
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().managerSubMenusArray[order] = value;
        }
    }

    public GameObject Building
    {
        get
        {
            return GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().buildingsArray[order];
        }
        set
        {
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().buildingsArray[order] = value;
        }
    }

    public GameObject BuildingSubMenu
    {
        get
        {
            return GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().buildingsSubMenusArray[order];
        }
        set
        {
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().buildingsSubMenusArray[order] = value;
        }
    }
    #endregion


    public float stock;
    public int order;

    [FoldoutGroup("Production Bools")]
    public bool isProduction, isManagerBought, isBuildingBought;

    [FoldoutGroup("Timers And Times")]
    public float timer, time;

    [FoldoutGroup("Upgrade")]
    public float MaterialCost, SpdUpgCost, IncUpgCost, BuildingCost, ManagerCost, SpdUpgLvl, IncUpgLvl, SpdUpgMultiplier, IncUpgMultiplier, SpdUpgCostMultiplier, IncUpgCostMultiplier;

    [SerializeField, FoldoutGroup("FullReset")] 
    float defaultTime, defaultStock, defaultMaterialCost, defaultSpdUpgCost, defaultIncUpgCost, defaultIncUpgLvl, defaultSpdUpgLvl;
    

    public void SellMaterial()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().money += (stock * MaterialCost); //I couldn't find it with name IDK why, Scriptable object doesn't hold when you drag and drop things, and at last I did this.
        stock = 0;
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().moneyText.text = "$" + Money.ToString();
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    public void SpeedUpgrade()
    {
        if (Money >= SpdUpgCost)
        {
            Money -= SpdUpgCost;
            SpeedUpgrade1();
        }
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().moneyText.text = "$" + Money.ToString();
    }
    public void SpeedUpgrade1()
    {
        SpdUpgLvl += 1;
        SpdUpgCost *= SpdUpgCostMultiplier;
        SpdUpgCostText.text = "Upgrade For $" + SpdUpgCost;
        if (SpdUpgLvl % 10 == 0)
            time /= (SpdUpgMultiplier * 2); //Twice as fast at multiples of 10
        else
            time /= SpdUpgMultiplier;

        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().moneyText.text = "$" + Money.ToString();
    }
    ////////////////////////////////////////////////////////////////////////////////////////

    public void IncomeUpgrade()
    {
        if (Money >= IncUpgCost)
        {
            Money -= IncUpgCost;
            IncomeUpgrade1();
        }
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().moneyText.text = "$" + Money.ToString();
    }
    public void IncomeUpgrade1()
    {
        IncUpgLvl += 1;
        IncUpgCost *= IncUpgCostMultiplier;
        MaterialCost *= IncUpgMultiplier;
        IncUpgCostText.text = "Upgrade For $" + IncUpgCost;
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().moneyText.text = "$" + Money.ToString();
    }

    ////////////////////////////////////////////////////////////////////////////////////////
    public void BuyManager()
    {
        if (Money >= ManagerCost)
        {
            Money -= ManagerCost;
            isManagerBought = true;

            ManagerSubMenu.SetActive(false);
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().managerSubMenusArray[order].SetActive(false);
        }
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().moneyText.text = "$" + Money.ToString();
    }
    public void BuyBuilding()
    {
        if (Money >= BuildingCost)
        {
            Money -= BuildingCost;
            isBuildingBought = true;
            Building.SetActive(true);

            BuildingSubMenu.SetActive(false);

            ManagerSubMenu.SetActive(true);

            GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().prodButtonsAndFillbarsArray[order].SetActive(true);
        }
        var sayac = 0;
        var randomUpg = GameObject.FindGameObjectWithTag("RandomUpgrade").GetComponent<RandomUpgrade>();
        var som = GameObject.FindGameObjectWithTag("SOManager").GetComponent<SO_Manager>();
        for (int i = 0; i < som.objectsList.Count; i++)
        {
            if (som.objectsList[i].isBuildingBought == false)
            {
                sayac = 0;
                break;
            }
            else
            {
                sayac++;
            }
            if (sayac == 8)
            {
                randomUpg.isAllBuildingsBought = true;
                randomUpg.bonusClaimed = true;
            }
        }
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().moneyText.text = "$" + Money.ToString();
    }





    public void FullReset() //For testing, resets the values.
    {
        timer = 0;
        time = defaultTime;
        stock = defaultStock;
        MaterialCost = defaultMaterialCost;
        SpdUpgCost = defaultSpdUpgCost;
        IncUpgCost = defaultIncUpgCost;
        SpdUpgLvl = defaultSpdUpgLvl;
        IncUpgLvl = defaultIncUpgLvl;
        isManagerBought = false;
        isProduction = false;

        if (order != 0 && order != 4)
        {
            isBuildingBought = false;
        }
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().moneyText.text = "$" + Money.ToString();
    }
}

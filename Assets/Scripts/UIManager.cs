#region Namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using TMPro;
#endregion



public class UIManager : MonoBehaviour
{
    #region Scripts
    [FoldoutGroup("Scripts")] public GameManager gm;
    [FoldoutGroup("Scripts")] public UIManager UIM;
    [FoldoutGroup("Scripts")] public SO_Manager SOM;
    #endregion

    public TMP_Text moneyText;

    [FoldoutGroup("Fillbars")] public Image[] fillersArray;

    

    #region UI Switch Wood - Iron
    [FoldoutGroup("Prod Buttons & Fillbars")]
    public GameObject woodsButtonFillbarParent, ironsButtonFillbarParent;
    #endregion

    #region Menu Elements
    [SerializeField, FoldoutGroup("Menu Elements")] public GameObject menu;

    [SerializeField, FoldoutGroup("Menu Elements/Menus")] GameObject[] MenusArray;

    [SerializeField, FoldoutGroup("Menu Elements/Sell Menu Incomes")] TMP_Text[] SellIncomeTextsArray;

    [FoldoutGroup("Menu Elements/Speed&Income Upgrades Cost")] public TMP_Text[] SpdUpgCostTextsArray, IncUpgCostTextsArray;
    #endregion

    #region Buildings, fillbars and button; to unlock when purchased
    public GameObject[] prodButtonsAndFillbarsArray, buildingsArray;
    public GameObject[] buildingsSubMenusArray, managerSubMenusArray; //For closing setactive when bought
    #endregion





    private void Awake()
    {
        UIM = this;
    }

    private void Start()
    {
        SOM.objectsList[0].isBuildingBought = SOM.objectsList[4].isBuildingBought = true; //Wood and Iron Ore is always open, no need to purchase them

        #region Setting up some things
        for (int i = 0; i < 8; i++)
        {
            SpdUpgCostTextsArray[i].text = "Upgrade For $" + SOM.objectsList[i].SpdUpgCost;
            IncUpgCostTextsArray[i].text = "Upgrade For $" + SOM.objectsList[i].IncUpgCost;  //Speed and income upgrade buttons cost text
        }

        for (int i = 0; i < 8; i++)
        {
            if (SOM.objectsList[i].isBuildingBought == false) //If building not bought, then you can't hire the building's manager.
                managerSubMenusArray[i].SetActive(false);
        }
        #endregion
    }

    private void Update()
    {
        moneyText.text = "$" + gm.money.ToString();

        for (int i = 0; i < 8; i++)
        {
            SOM.StockTextsArray[i].text = SOM.objectsList[i].stock.ToString(); //Stock text display

            SellIncomeTextsArray[i].text = "Sell For $" + SOM.objectsList[i].stock * SOM.objectsList[i].MaterialCost; //sell buttons income text
        }
    }

    public void MenuOnOffButton()
    {
        switch (menu.activeInHierarchy)
        {
            case true:
                menu.SetActive(false);
                break;
            case false:
                menu.SetActive(true);
                break;
        }
    }

    public void MenusNav(int index) //Sub menu buttons
    {
        for (int i = 0; i < MenusArray.Length; i++)
        {
            MenusArray[i].SetActive(false);
        }
        MenusArray[index].SetActive(true);
    }

    
}

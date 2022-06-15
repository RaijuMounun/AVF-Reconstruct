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
    [FoldoutGroup("Scripts")] public Production prd;
    [FoldoutGroup("Scripts")] public UIManager UIM;
    [FoldoutGroup("Scripts")] public SO_Manager SOM;
    #endregion

    public TMP_Text moneyText;

    [FoldoutGroup("Fillbars")] public Image[] fillersArray;

    #region Camera Pos
    [SerializeField, FoldoutGroup("Camera Pos")] public bool CameraInWood = true;
    [SerializeField, FoldoutGroup("Camera Pos")] public GameObject Camera;
    [SerializeField, FoldoutGroup("Camera Pos")] public Vector3 CameraWoodPivot, CameraIronPivot;
    #endregion

    #region UI Switch Wood - Iron
    [FoldoutGroup("Prod Buttons & Fillbars")]
    public GameObject woodsButtonFillbarParent, ironsButtonFillbarParent;
    #endregion

    #region Menu Elements
    [SerializeField, FoldoutGroup("Menu Elements")] public bool isMenuOpen = false;
    [SerializeField, FoldoutGroup("Menu Elements")] public GameObject menu;

    [SerializeField, FoldoutGroup("Menu Elements/Menus")] GameObject SellMenu, SpdUpgMenu, IncUpgMenu, ManagersMenu, BuildingsMenu, PrestigeMenu;
    [SerializeField, FoldoutGroup("Menu Elements/Menus")] GameObject[] MenusArray;

    [SerializeField, FoldoutGroup("Menu Elements/Sell Menu Incomes")] TMP_Text WoodSellIncomeText, TimberSellIncomeText, TableSellIncomeText, PaintedSellIncomeText, IronOreSellIncomeText, IronIngotSellIncomeText, NailSellIncomeText, GearSellIncomeText;
    [SerializeField, FoldoutGroup("Menu Elements/Sell Menu Incomes")] TMP_Text[] SellIncomeTextsArray;

    [SerializeField, FoldoutGroup("Menu Elements/Speed&Income Upgrades Cost")] TMP_Text[] SpdUpgCostTextsArray;
    [SerializeField, FoldoutGroup("Menu Elements/Speed&Income Upgrades Cost")] TMP_Text[] IncUpgCostTextsArray;
    #endregion

    #region Buildings, fillbars and button; to unlock when purchased
    [SerializeField] GameObject[] _ProdButtonsAndFillbarsArray;
    [SerializeField] GameObject[] _BuildingsArray;
    [SerializeField] GameObject[] _BuildingsSubMenusArray; //For closing setactive when bought
    [SerializeField] GameObject[] _ManagerSubMenusArray; //For closing again
    #endregion

    private void Awake()
    {
        UIM = this;
        isMenuOpen = false;
    }

    private void Start()
    {
        SOM.objectsList[0].isBuildingBought = SOM.objectsList[4].isBuildingBought = true; //Wood and Iron Ore is always open, no need to purchase them
    }

    private void Update()
    {
        #region Stocks text display
        for (int i = 0; i < 8; i++)
        {
            SOM.StockTextsArray[i].text = SOM.objectsList[i].stock.ToString();
        }
        #endregion

        #region UI Display Switch        
        woodsButtonFillbarParent.SetActive(CameraInWood);
        ironsButtonFillbarParent.SetActive(!CameraInWood);
        #endregion

        #region Camera Position
        if (CameraInWood)
        {
            Camera.transform.position = CameraWoodPivot;
        }
        else
        {
            Camera.transform.position = CameraIronPivot;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CameraSwitch();
        }
        #endregion

        #region Menu Button Texts
        for (int i = 0; i < SellIncomeTextsArray.Length; i++) //Sell button income texts
            SellIncomeTextsArray[i].text = "Sell For $" + SOM.objectsList[i].stock * SOM.objectsList[i].MaterialCost;

        for (int i = 0; i < 8; i++) //Speed & income upgrade button cost text
        {
            SpdUpgCostTextsArray[i].text = "Upgrade For $" + SOM.objectsList[i].SpdUpgCost;
            IncUpgCostTextsArray[i].text = "Upgrade For $" + SOM.objectsList[i].IncUpgCost;
        }
        #endregion

        #region Buildings and fillbars & Produce buttons. When building bought, these are turning on
        for (int i = 0; i < _BuildingsArray.Length; i++)
        {
            _ProdButtonsAndFillbarsArray[i].SetActive(SOM.objectsList[i].isBuildingBought);
            _BuildingsArray[i].SetActive(SOM.objectsList[i].isBuildingBought);
        }
        #endregion

        #region Manager Menu Materials, when bought these are turning off
        for (int i = 0; i < 8; i++)
        {
            _ManagerSubMenusArray[i].SetActive(!SOM.objectsList[i].isManagerBought);
        }
        #endregion

        #region Buildings Menu Materials, when bought, set setactive false
        for (int i = 0; i < 8; i++)
        {
            if ((i==0) && (i==4))
            {
                continue;
            }
            _BuildingsSubMenusArray[i].SetActive(!SOM.objectsList[i].isBuildingBought);
        }
        #endregion

        #region If building not bought, then you can't hire the building's manager.
        for (int i = 0; i < 8; i++)
        {
            if (SOM.objectsList[i].isBuildingBought == false)
            {
                _ManagerSubMenusArray[i].SetActive(false);
            }
        }
        #endregion

        moneyText.text = "$" + gm.money.ToString();

        menu.SetActive(isMenuOpen);
    }

    public void MenuOnOffButton() { isMenuOpen = !isMenuOpen; }

    public void CameraSwitch() { CameraInWood = !CameraInWood; }



    public void MenusNav(int index) //Sub menu buttons
    {
        for (int i = 0; i < MenusArray.Length; i++)
        {
            MenusArray[i].SetActive(false);
        }
        MenusArray[index].SetActive(true);
    }
}

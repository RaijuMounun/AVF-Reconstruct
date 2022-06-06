using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class UIManager : MonoBehaviour
{
    #region Scripts
    [SerializeField, FoldoutGroup("Scripts")]
    public GameManager gm;
    [SerializeField, FoldoutGroup("Scripts")]
    public Data data;
    [SerializeField, FoldoutGroup("Scripts")]
    public Production prd;
    [SerializeField, FoldoutGroup("Scripts")]
    public UIManager UIM;
    #endregion

    #region Stocks
    [SerializeField, FoldoutGroup("Stocks")]
    Text _woodStockText, _timberStockText, _tableStockText, _paintedStockText, _ironOreStockText, _ironIngotStockText, _nailStockText, _gearStockText;

    public List<Text> stockTextsList = new List<Text>();
    #endregion

    #region Fillbars
    [SerializeField, FoldoutGroup("Fillbars")]
    public Image _woodFiller, _timberFiller, _tableFiller, _paintedFiller;//, _ironOreFiller, _ironIngotFiller, _nailFiller, _gearFiller;
    #endregion

    #region UI Switch Wood - Iron
    [FoldoutGroup("SWITCH")]
    [SerializeField, FoldoutGroup("SWITCH/Prod Buttons & Fillbars")]
    GameObject _woodsButtonFillbarParent, _ironsButtonFillbarParent;
    #endregion


    private void Awake()
    {
        UIM = this;
    }

    private void Start()
    {
        stockTextsList.Add(_woodStockText);
        stockTextsList.Add(_timberStockText);
        stockTextsList.Add(_tableStockText);
        stockTextsList.Add(_paintedStockText);
        stockTextsList.Add(_ironOreStockText);
        stockTextsList.Add(_ironIngotStockText);
        stockTextsList.Add(_nailStockText);
        stockTextsList.Add(_gearStockText);
    }



    private void Update()
    {
        //Text Displays but The array is not updated even though the value has changed, so this is not working.
        for (int i = 0; i < stockTextsList.Count; i++)
        {
            stockTextsList[i].text = data.stocksArray[i] + "";
        }


        //UI Display Switch        
        _woodsButtonFillbarParent.SetActive(gm._CameraInWood);
        _ironsButtonFillbarParent.SetActive(!gm._CameraInWood);
        
    }
}

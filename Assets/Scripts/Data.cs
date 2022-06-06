using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Data : MonoBehaviour
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
    [FoldoutGroup("Stocks")]
    public float _woodStock, _timberStock, _tableStock, _paintedStock, _ironOreStock, _ironIngotStock, _nailStock, _gearStock;

    //public List<float> stocksList = new List<float>();
    public float[] stocksArray;
    #endregion





    private void Awake()
    {
        data = this;
    }

    private void Start()
    {
        stocksArray = new float[8];

        stocksArray[0] = _woodStock;
        stocksArray[1] = _timberStock;
        stocksArray[2] = _tableStock;
        stocksArray[3] = _paintedStock;
        stocksArray[4] = _ironOreStock;
        stocksArray[5] = _ironIngotStock;
        stocksArray[6] = _nailStock;
        stocksArray[7] = _gearStock;

        /*
        stocksList.Add(_woodStock);
        stocksList.Add(_timberStock);
        stocksList.Add(_tableStock);
        stocksList.Add(_paintedStock);
        stocksList.Add(_ironOreStock);
        stocksList.Add(_ironIngotStock);
        stocksList.Add(_nailStock);
        stocksList.Add(_gearStock);*/
    }
}

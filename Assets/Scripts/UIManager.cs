using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class UIManager : MonoBehaviour
{
    [SerializeField, FoldoutGroup("Scripts")]
    public GameManager gm;
    [SerializeField, FoldoutGroup("Scripts")]
    public Data data;
    [SerializeField, FoldoutGroup("Scripts")]
    public Production prd;
    [SerializeField, FoldoutGroup("Scripts")]
    public UIManager UIM;



    [SerializeField, FoldoutGroup("Stocks")]
    Text _woodStockText, _timberStockText, _tableStockText, _paintedStockText, _ironOreStockText, _ironIngotStockText, _nailStockText, _gearStockText;


    private void Awake()
    {
        UIM = this;
    }



    private void Update()
    {
        _woodStockText.text = data._woodStock + "";
    }
}

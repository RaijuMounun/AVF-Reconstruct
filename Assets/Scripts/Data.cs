using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Data : MonoBehaviour
{
    [SerializeField, FoldoutGroup("Scripts")]
    public GameManager gm;
    [SerializeField, FoldoutGroup("Scripts")]
    public Data data;
    [SerializeField, FoldoutGroup("Scripts")]
    public Production prd;
    [SerializeField, FoldoutGroup("Scripts")]
    public UIManager UIM;





    [FoldoutGroup("Stocks")]
    public float _woodStock, _timberStock, _tableStock, _paintedStock, _ironOreStock, _ironIngotStock, _nailStock, _gearStock;






    private void Awake()
    {
        data = this;
    }
}

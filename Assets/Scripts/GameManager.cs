using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;


public class GameManager : MonoBehaviour //I thought I needed this more but...
{
    #region Variables

    #region Scripts
    [FoldoutGroup("Scripts")] public GameManager gm;
    [FoldoutGroup("Scripts")] public Production prd;
    [FoldoutGroup("Scripts")] public UIManager UIM;
    [FoldoutGroup("Scripts")] public SO_Manager SOM;
    #endregion


    public float money;
    #endregion


    private void Awake()
    {
        gm = this;
    }


    
}

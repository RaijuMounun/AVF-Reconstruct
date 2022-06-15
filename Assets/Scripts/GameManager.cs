using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;


public class GameManager : MonoBehaviour //I thought I needed this more but...
{
    #region Variables

    [FoldoutGroup("Scripts")] public GameManager gm;
    public float money;
    #endregion


    private void Awake()
    {
        gm = this;
    }


    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityEditor;


public class GameManager : MonoBehaviour 
{
    #region Variables

    [FoldoutGroup("Scripts")] public GameManager gm; 
    [FoldoutGroup("Scripts")] public SO_Manager SOM;
    public float money;
    #endregion

    private void Awake() => gm = this;

    public void SetFullReset()
    {
        for (int i = 0; i < 8; i++)
        {
            SOM.objectsList[i].FullReset();
        }
    }
}

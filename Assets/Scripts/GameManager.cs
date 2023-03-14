using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityEditor;


public class GameManager : MonoBehaviour //I thought I needed this more but...
{
    #region Variables

    [FoldoutGroup("Scripts")] public GameManager gm; //The reason I didn't use static here is I had a problem with static, but I don't know why and I did this, problem solved.
    [FoldoutGroup("Scripts")] public SO_Manager SOM;
    public bool fullReset = false;
    public float money;
    #endregion

    private void Awake()
    {
        gm = this;
    }

    private void Update()
    {
        if (fullReset == true)
        {
            for (int i = 0; i < 8; i++)
            {
                SOM.objectsList[i].FullReset();
            }
            fullReset = false;
        }
            

    }
}

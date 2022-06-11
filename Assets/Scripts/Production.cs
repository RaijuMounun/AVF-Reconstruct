using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class Production : MonoBehaviour
{
    #region Scripts
    [FoldoutGroup("Scripts")] public GameManager gm;
    [FoldoutGroup("Scripts")] public Production prd;
    [FoldoutGroup("Scripts")] public UIManager UIM;
    [FoldoutGroup("Scripts")] public SO_Manager SOM;
    #endregion

    private void Awake()
    {
        prd = this;
    }

    private void Update()
    {
        #region Production
        for (int i = 0; i < 8; i++)
        {
            if (SOM.objectsList[i].isManagerBought) // I should make this different but IDK. It's future Eren's problem. If manager is bought, automates the production.
            {
                SOM.objectsList[i].isProduction = true;
                SOM.ProduceButtonsArray[i].SetActive(false);
            }

            if (SOM.objectsList[i].isProduction)
            {
                SOM.AnimatorsArray[i].enabled = true;

                SOM.objectsList[i].timer += Time.deltaTime;
                if (SOM.objectsList[i].timer >= SOM.objectsList[i].time)
                {
                    SOM.objectsList[i].timer = 0;
                    SOM.objectsList[i].stock += 1;
                    SOM.objectsList[i].isProduction = false;
                }

            }
            else
                SOM.AnimatorsArray[i].enabled = false;

            UIM.fillersArray[i].fillAmount = SOM.objectsList[i].timer / SOM.objectsList[i].time;
        }        
        #endregion
    }

    #region Button Functions
    public void WoodCutButton()
    {
        SOM.objectsList[0].isProduction = true;
    }
    public void TimberSawButton()
    {
        SOM.objectsList[1].isProduction = true;
    }
    public void TableMakeButton()
    {
        SOM.objectsList[2].isProduction = true;
    }
    public void PaintedPaintButton()
    {
        SOM.objectsList[3].isProduction = true;
    }
    public void IronOreDigButton()
    {
        SOM.objectsList[4].isProduction = true;
    }
    public void IronIngotMeltButton()
    {
        SOM.objectsList[5].isProduction = true;
    }
    public void NailPressButton()
    {
        SOM.objectsList[6].isProduction = true;
    }
    public void GearCastButton()
    {
        SOM.objectsList[7].isProduction = true;
    }
    #endregion
}

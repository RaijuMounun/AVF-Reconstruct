using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class Production : MonoBehaviour
{
    #region Scripts
    [FoldoutGroup("Scripts")] public Production prd;
    [FoldoutGroup("Scripts")] public UIManager UIM;
    [FoldoutGroup("Scripts")] public SO_Manager SOM;
    #endregion

    private void Awake() => prd = this;

    private void Update()
    {
        #region Production
        for (int i = 0; i < 8; i++)
        {
            if (SOM.objectsList[i].isManagerBought) // If manager is bought, automates the production.
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

    public void ProductionButtons(int index) => SOM.objectsList[index].isProduction = true;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class Production : MonoBehaviour
{
    #region Variables
    [SerializeField, FoldoutGroup("Scripts")]
    public GameManager gm;
    [SerializeField, FoldoutGroup("Scripts")]
    public Data data;
    [SerializeField, FoldoutGroup("Scripts")]
    public Production prd;
    [SerializeField, FoldoutGroup("Scripts")]
    public UIManager UIM;

    [SerializeField, FoldoutGroup("Production Bools")]
    bool _woodProduction, _woodManagerBought;

    [SerializeField, FoldoutGroup("Timers And Times")]
    float _woodTimer, _woodTime;

    [SerializeField, FoldoutGroup("Animators")]
    Animator _axeAnimator;

    [SerializeField, FoldoutGroup("Prod Button GObjects")]
    GameObject _woodCutButton;

    #endregion

    private void Awake()
    {
        prd = this;
    }


    private void Update()
    {
        #region Wood Production, I couldn't make them in function, pls help.
        if (_woodManagerBought)
        {
            _woodProduction = true;
            _woodCutButton.SetActive(false);
        }

        if (_woodProduction)
        {
            _axeAnimator.enabled = true;

            _woodTimer += Time.deltaTime;
            if (_woodTimer >= _woodTime)
            {
                _woodTimer = 0;
                data._woodStock += 1;
                _woodProduction = false;
            }

        }
        else
        {
            _axeAnimator.enabled = false;
        }
        #endregion
    }

    


    #region Button Functions
    public void WoodCutButton()
    {
        _woodProduction = true;
    }
    #endregion
}

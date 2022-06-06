using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class GameManager : MonoBehaviour
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

    [SerializeField, FoldoutGroup("Bools")]
    public bool _CameraInWood = true;

    [SerializeField, FoldoutGroup("Gameobjects")]
    GameObject _Camera;

    #endregion


    private void Awake()
    {
        gm = this;
    }

    private void Update()
    {
        #region Camera Position
        if (_CameraInWood)
        {
            _Camera.transform.position = new Vector3(-25,20,-25);
        }
        else
        {
            _Camera.transform.position = new Vector3(75,20,75);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _CameraInWood = !_CameraInWood;
        }
        #endregion
    }
}

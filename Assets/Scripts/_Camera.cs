using UnityEngine;
using Sirenix.OdinInspector;

public class _Camera : MonoBehaviour
{
    public UIManager UIM;

    [SerializeField, FoldoutGroup("Camera Pos")] public bool CameraInWood = true;
    [SerializeField, FoldoutGroup("Camera Pos")] public GameObject Camera;
    [SerializeField, FoldoutGroup("Camera Pos")] public Vector3 CameraWoodPivot, CameraIronPivot;


    private void Update()
    {
        #region UI Display Switch        
        UIM.woodsButtonFillbarParent.SetActive(CameraInWood);
        UIM.ironsButtonFillbarParent.SetActive(!CameraInWood);
        #endregion


        #region Camera Position
        if (CameraInWood)
        {
            Camera.transform.position = CameraWoodPivot;
        }
        else
        {
            Camera.transform.position = CameraIronPivot;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CameraSwitch();
        }
        #endregion
    }


    public void CameraSwitch() { CameraInWood = !CameraInWood; }
}

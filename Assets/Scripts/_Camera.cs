using UnityEngine;
using Sirenix.OdinInspector;

public class _Camera : MonoBehaviour
{
    public UIManager UIM;

    [FoldoutGroup("Camera Pos")] public bool cameraInWood = true;
    [FoldoutGroup("Camera Pos")] public Transform camera_;
    [FoldoutGroup("Camera Pos")] public Vector3 cameraWoodPivot, cameraIronPivot;


    private void Update()
    {
        #region Camera Position

        switch (cameraInWood)
        {
            case false:
                camera_.position = cameraIronPivot;
                break;

            default:
                camera_.position = cameraWoodPivot;
                break;
        }


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CameraSwitch();
        }
        #endregion
    }


    public void CameraSwitch() 
    { 
        cameraInWood = !cameraInWood;
        UIM.woodsButtonFillbarParent.SetActive(cameraInWood);
        UIM.ironsButtonFillbarParent.SetActive(!cameraInWood);

    }
}

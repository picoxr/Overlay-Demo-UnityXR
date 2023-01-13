using UnityEngine;
using Unity.XR.PXR;

/// <summary>
/// 刷新RT图至Hole、Overlay
/// </summary>
public class UpdateOverlayTexture : MonoBehaviour
{
    [SerializeField]
    private Camera m_uiCamera;
    /*
    [SerializeField]
    private MeshRenderer m_hole;
    [SerializeField]
    private PXR_OverLay m_overlay;
    */
    void Start()
    {
        if (m_uiCamera != null && m_uiCamera.targetTexture != null)
        {
            ControllerPhysicRaycastManager.Instance.RT_Size = new Vector2(m_uiCamera.targetTexture.width, m_uiCamera.targetTexture.height);
        }
    }

    /*
    private void Update()
    {
        m_hole.material.mainTexture = m_uiCamera.targetTexture;
        m_overlay.SetTexture(m_uiCamera.targetTexture, false);
    }
    */
}

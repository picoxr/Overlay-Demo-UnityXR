using UnityEngine;

/// <summary>
/// 刷新RT图至Hole、Overlay
/// </summary>
public class UpdateOverlayTexture : MonoBehaviour
{
    [SerializeField]
    private Camera m_uiCamera;

    void Start()
    {
        if (m_uiCamera != null && m_uiCamera.targetTexture != null)
        {
            ControllerPhysicRaycastManager.Instance.RT_Size = new Vector2(m_uiCamera.targetTexture.width, m_uiCamera.targetTexture.height);
        }
    }
}

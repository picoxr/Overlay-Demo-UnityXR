using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;

/// <summary>
/// 刷新RT图至Hole、Overlay
/// </summary>
public class UpdateOverlayTexture : MonoBehaviour
{
    [SerializeField]
    private Camera m_uiCamera;

    [SerializeField]
    private MeshRenderer m_hole;

    
    private  PXR_OverLay m_overlay;

    void Start()
    {
        ControllerPhysicRaycastManager.Instance.RT_Size =
            new Vector2(m_uiCamera.targetTexture.width, m_uiCamera.targetTexture.height);
    }


    // Update is called once per frame
    void Update()
    {

        m_hole.material.mainTexture = m_uiCamera.targetTexture;
        m_overlay.SetTexture(m_uiCamera.targetTexture,false);
    }
}

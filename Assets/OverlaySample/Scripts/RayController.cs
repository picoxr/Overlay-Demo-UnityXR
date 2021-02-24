using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;
using UnityEngine.XR;


/// <summary>
/// 控制使用的ray
/// </summary>
public class RayController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] starts;

    [SerializeField]
    private GameObject[] dots;

    private int hand;

    [SerializeField]
    private GameObject m_head;
    //[SerializeField]
    //private GameObject m_cursor;


    private PXR_Input.Controller controller;

    private int num;

    private bool lTriggerButton;

    // Update is called once per frame
    void Update()
    {
        
        if ((InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.triggerButton, out lTriggerButton) && lTriggerButton) && PXR_Input.IsControllerConnected(PXR_Input.Controller.LeftController))
        {
            ControllerPhysicRaycastManager.Instance.ray =
                new Ray(starts[0].transform.position, starts[0].transform.forward);
        }


        if ((InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.triggerButton, out lTriggerButton) && lTriggerButton) && PXR_Input.IsControllerConnected(PXR_Input.Controller.RightController))
        {
            ControllerPhysicRaycastManager.Instance.ray =
                new Ray(starts[1].transform.position, starts[1].transform.forward);
        }
        
    }

}

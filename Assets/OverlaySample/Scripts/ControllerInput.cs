using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;
using UnityEngine.XR;

public class ControllerInput  {

    private static PXR_Input.Controller hand;
    
    private static bool lPrimary2DButton, lTriggerButton, A , B, X, Y;


    public static Vector3 controllerPosition;

    public static bool controllerPresent = false;


    public static bool GetController()
    {
        return (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.primary2DAxisClick, out lPrimary2DButton) && lPrimary2DButton)||
               (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.triggerButton, out lTriggerButton) && lTriggerButton) ||
               (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.primaryButton, out X) && X) ||
               (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.secondaryButton, out Y)&& Y) ||
               (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.primary2DAxisClick, out lPrimary2DButton) && lPrimary2DButton) ||
               (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.triggerButton, out lTriggerButton) && lTriggerButton) ||
               (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.primaryButton, out A) && A) ||
               (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.secondaryButton, out B) && B) ||
               Input.GetButton("Submit") || Input.GetMouseButton(0);
    }


}

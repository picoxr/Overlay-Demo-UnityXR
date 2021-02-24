using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControllerPhysicRaycastManager : MonoBehaviour {

    private static ControllerPhysicRaycastManager m_Instance;

    public static ControllerPhysicRaycastManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GameObject("ControllerPhysicRaycastManager").
                    AddComponent<ControllerPhysicRaycastManager>();
            }
            return m_Instance;
        }
    }

    public Action<RaycastHit> onScreenAction;

    public Ray ray;
    public Vector2 RT_Size = Vector2.zero;

    private RaycastHit hit;


    void Update()
    {
        Debug.DrawLine(ray.origin, ray.direction, Color.yellow, 1f);
        if(Physics.Raycast(ray,out hit))
        {
           if(hit.transform.gameObject.layer == 9)
           {
               ControllerInput.controllerPresent = true;
                ControllerInput.controllerPosition = new Vector3(hit.textureCoord.x * RT_Size.x,
                    hit.textureCoord.y * RT_Size.y, 0f);
           }
            else
            {
                ControllerInput.controllerPosition = Vector3.zero;
            }
            
        }
        else
        {
            ControllerInput.controllerPosition = Vector3.zero;
        }

    }

}

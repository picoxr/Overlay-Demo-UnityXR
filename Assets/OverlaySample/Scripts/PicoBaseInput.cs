using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PicoBaseInput : BaseInput
{
    public override bool mousePresent
    {
        get
        {
            return ControllerInput.controllerPresent;
        }
    }

    public override bool GetMouseButtonDown(int button)
    {
        if (button == 0)
        {
            return ControllerInput.GetController();
        }
        else
            return false;
        
    }

    public override bool GetMouseButtonUp(int button)
    {
        if (button == 0)
        {
            return ControllerInput.GetController();
        }
          
        else
            return false;
        
    }

    public override bool GetMouseButton(int button)
    {
        if (button == 0)
        { 
            return ControllerInput.GetController();
        }
        else
            return false;
        
    }


    public override Vector2 mousePosition
    {
        get
        {
            return ControllerInput.controllerPosition;
        }
    }

    public override Vector2 mouseScrollDelta
    {
        get
        {
            return Vector2.zero;
        }
    }

    public override bool touchSupported
    {
        get
        {
            return false;
        }
    }

    public override int touchCount
    {
        get
        {
            return base.touchCount;
        }
    }

    public override Touch GetTouch(int index)
    {
        return base.GetTouch(index);
    }


    public override bool GetButtonDown(string buttonName)
    {
        Debug.Log(buttonName);
        return base.GetButtonDown(buttonName);
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PUIInPutModule : StandaloneInputModule
{
  protected  override void Awake()
    {
        m_InputOverride = GetComponent<BaseInput>();
    }

    protected override void Start()
    {
        
    }
    public GameObject hoverObj
    {
        get
        {
            return GetCurrentFocusedGameObject();
        }
    }
    private void Update()
    {
        
    }
}

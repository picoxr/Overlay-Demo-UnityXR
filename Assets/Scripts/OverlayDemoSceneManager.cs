using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.PXR;
using UnityEngine.UI;

public class OverlayDemoSceneManager : MonoBehaviour
{
    public Text DynamicNumberText;


    private int m_Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        ChangeNumberPerSecond();
    }

    // Update is called once per frame
    void Update()
    {
        //UIOverlay.SetTexture(m_OverlayRT, true);
    }


    private void ChangeNumberPerSecond()
    {
        DynamicNumberText.text = "Current Number = " + m_Count;
        m_Count++;
        Invoke("ChangeNumberPerSecond", 1.0f);
    }

    public void OnClickUIButton()
    {
        m_Count = 0;
    }
}

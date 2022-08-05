# Overlay-Demo-UnityXR

- If you have any questions/comments, please visit [**Pico Developer Answers**](https://devanswers.pico-interactive.com/) and raise your question there.

1. Create a Camera that is only used for UI rendering. And remove other camera from the UI layer. UI uses Unity’s default interactive class. It is shown as below:

   <img src="./ReadMeScreenshot/1-1.png"  width = "600"/>

   <img src="./ReadMeScreenshot/1-2.png"  width = "600" />

2. Remove InputModule script within EventSystem, and add PUIInPutModule class and PicoBaseInput class as shown below:

   <img src="./ReadMeScreenshot/2-1.png"  width = "600"/>

3. Create a RenderTexture whose size must be big enough to display complete UI. Assign RenderTexture to the UICamera created.

   <img src="./ReadMeScreenshot/3-1.png" width = "600" />

   <img src="./ReadMeScreenshot/3-2.png"  width = "600"/>

4. Create a material which uses UnderlayHole.

   <img src="./ReadMeScreenshot/4-1.png"  width = "600"/>

5. Create a Quad named as Hole (or else). The scale and position of Hole are subject to actual needs, but its aspect ratio should be consistent with that of TargetTexture in UICamera. Assign UnderlayHole to Quad. 

   <img src="./ReadMeScreenshot/5-1.png" width = "600" />

6. Create a new Quad named as Overlay (or else). Uncheck Box Collider and Mesh Render, and add PXR_OverLay class in Overlay. Transform information should stay the same as Hole.

   <img src="./ReadMeScreenshot/6-1.png"  width = "600"/>

7. Assignment of the two parameters in ControllerPhysicRaycastManager class is necessary. The assignment for ray need to be updated per frame (normally the value is the direction of ray), and assign the Size of TargetTexture in UICamera to RT_Size, (i.e., Size of RenderTexture).

   <img src="./ReadMeScreenshot/7-1.png" width = "600" />

   Hole is the only detection object of rays, but detection codes  can be modified based on actual needs.

   <img src="./ReadMeScreenshot/7-2.png" width = "600" />

8. Update RenderTexture to Hole and Overlay per frame.

   <img src="./ReadMeScreenshot/8-1.png" width = "600" />


## Note:
- This demo is implemented in Unity 2020.3.36f1.


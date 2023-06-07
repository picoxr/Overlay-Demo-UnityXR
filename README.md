# Overlay-Demo-UnityXR

- If you have any questions/comments, please visit [**Pico Developer Support Portal**](https://picodevsupport.freshdesk.com/support/home) and raise your question there.

# Development environment
Unity 2020.3.45f1
PICO Unity XR Interaction SDK v2.1.5

# Description
This demo shows PICO Unity SDK Overlay related features. Please can take the **Demo_Overlay** scene for reference.
In the scene, **VideoPlayerOverlay** gameobject is used to display 360 video, to make the video play properly please update the "Movie Name" defined in PXR_OverlayExternalSurfaceDemo.cs or simply modify your 360 video name to test360.mp4 and place it on PICO device external storeage root path (/sdcard/).
And the **UnderlayHole** gameobject is used to dig the holes to show Underlay image, without it all the underlay elements cannot be seen on the device.
Finally the **OverlayUICamera** is used to show Overlay UI, which is clearer then the original one rendered by Unity.


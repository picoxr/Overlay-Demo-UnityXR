// Copyright  2015-2020 Pico Technology Co., Ltd. All Rights Reserved.


using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;

public class PXR_OverlayExternalSurfaceDemo : MonoBehaviour {

    public string movieName;

    public PXR_OverLay.OverlayType overlayType;
    public PXR_OverLay.OverlayShape overlayShape;

    private PXR_OverLay overlay = null;

    private const string TAG = "[ExternalSurface]>>>>>>";

    private static System.IntPtr playVideoMethodId;
    private static jvalue[] playVideoParams;
    private static System.IntPtr? _VideoPlayerClass;
    private static System.IntPtr? _Activity;

    private static System.IntPtr VideoPlayerClass
    {
        get
        {
            if (!_VideoPlayerClass.HasValue)
            {
                try
                {
                    System.IntPtr myVideoPlayerClass = AndroidJNI.FindClass("com/pico/exoplayerdemo/PlayVideo");

                    if (myVideoPlayerClass != System.IntPtr.Zero)
                    {
                        _VideoPlayerClass = AndroidJNI.NewGlobalRef(myVideoPlayerClass);

                        AndroidJNI.DeleteLocalRef(myVideoPlayerClass);
                    }
                    else
                    {
                        Debug.LogError(TAG + "Failed to find NativeVideoPlayer class");
                        _VideoPlayerClass = System.IntPtr.Zero;
                    }
                }
                catch (System.Exception ex)
                {
                    Debug.LogError(TAG + "Failed to find NativeVideoPlayer class");
                    Debug.LogException(ex);
                    _VideoPlayerClass = System.IntPtr.Zero;
                }
            }
            return _VideoPlayerClass.GetValueOrDefault();
        }
    }

    private static System.IntPtr Activity
    {
        get
        {
            if (!_Activity.HasValue)
            {
                try
                {
                    System.IntPtr unityPlayerClass = AndroidJNI.FindClass("com/unity3d/player/UnityPlayer");
                    System.IntPtr currentActivityField = AndroidJNI.GetStaticFieldID(unityPlayerClass, "currentActivity", "Landroid/app/Activity;");
                    System.IntPtr activity = AndroidJNI.GetStaticObjectField(unityPlayerClass, currentActivityField);

                    _Activity = AndroidJNI.NewGlobalRef(activity);

                    AndroidJNI.DeleteLocalRef(activity);
                    AndroidJNI.DeleteLocalRef(unityPlayerClass);
                }
                catch (System.Exception ex)
                {
                    Debug.LogException(ex);
                    _Activity = System.IntPtr.Zero;
                }
            }
            return _Activity.GetValueOrDefault();
        }
    }

    private void Awake()
    {
        overlay = GetComponent<PXR_OverLay>();
        if (overlay == null)
        {
            Debug.LogError(TAG + "PXRLog Overlay is null!");
            overlay = gameObject.AddComponent<PXR_OverLay>();
        }

        overlay.overlayType = overlayType;
        overlay.overlayShape = overlayShape;
        overlay.isExternalAndroidSurface = true;
    }

    // Use this for initialization
    void Start()
    {
        if (!string.IsNullOrEmpty(movieName))
        {
            StartPlay(movieName, null);
        }
    }


    void StartPlay(string moviePath, string licenceUrl)
    {
        if (moviePath != string.Empty)
        {
            if (overlay.isExternalAndroidSurface)
            {
                Debug.Log("[DragonTest] surfaceObjectCreatedCallback");
                PXR_OverLay.ExternalAndroidSurfaceObjectCreated surfaceObjectCreatedCallback = () =>
                {
                    Debug.Log(TAG+"PXRLog SurfaceObject created callback is Invoke().");
                    // TODO:
                    // You need pass externalAndroidSurfaceObject to one android video player for video texture updates.
                    // eg.if you use Android ExoPlayer,you can call exoPlayer.setVideoSurface( surface
                    System.IntPtr filePathJString = AndroidJNI.NewStringUTF(moviePath);

                    playVideoMethodId = AndroidJNI.GetStaticMethodID(VideoPlayerClass, "playVideo", "(Landroid/content/Context;Ljava/lang/String;Landroid/view/Surface;)V");
                    playVideoParams = new jvalue[3];

                    playVideoParams[0].l = Activity;
                    playVideoParams[1].l = filePathJString;
                    playVideoParams[2].l = overlay.externalAndroidSurfaceObject;
                    AndroidJNI.CallStaticVoidMethod(VideoPlayerClass, playVideoMethodId, playVideoParams);

                    AndroidJNI.DeleteLocalRef(filePathJString);
                };

                if (overlay.externalAndroidSurfaceObject == System.IntPtr.Zero)
                {
                    Debug.Log(TAG + "PXRLog Register surfaceObject created callback");
                    overlay.externalAndroidSurfaceObjectCreated = surfaceObjectCreatedCallback;
                }
                else
                {
                    Debug.Log(TAG + "PXRLog SurfaceObject is already created! Invoke callback");
                    surfaceObjectCreatedCallback.Invoke();
                }
            }
        }
        else
        {
            Debug.LogError(TAG + "PXRLog Movie path is null!");
        }
    }
}

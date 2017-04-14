#region

using UnityEngine;

#endregion

public class DeviceDetect : MonoBehaviour
{
    public GameObject Canvas;

    private void Start()
    {
        #if UNITY_STANDALONE
           Canvas.SetActive(false);
        #endif
        #if UNITY_IPHONE
           Canvas.SetActive(true);
        #endif
        #if UNITY_ANDROID
            Canvas.SetActive(true);
        #endif
        #if UNITY_WP_8_1
            Canvas.SetActive(true);
        #endif
        #if UNITY_WSA
            Canvas.SetActive(true);
        #endif
        #if UNITY_WINRT
            Canvas.SetActive(true);
        #endif
    }
}
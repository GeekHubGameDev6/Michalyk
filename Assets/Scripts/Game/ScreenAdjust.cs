#region

using UnityEngine;

#endregion

public class ScreenAdjust : MonoBehaviour
{
    private void Start()
    {
        var targetaspect = 16.0f / 10.0f;
        var windowaspect = Screen.width / (float) Screen.height;
        var scaleheight = windowaspect / targetaspect;
        var camera = GetComponent<Camera>();
        if (scaleheight < 1.0f)
        {
            var rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;
            camera.rect = rect;
        }
        else
        {
            var scalewidth = 1.0f / scaleheight;
            var rect = camera.rect;
            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }
}
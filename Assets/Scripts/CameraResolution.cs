using UnityEngine;

/// <summary>
///     Skrypt odpowiada za usatwienie rozdzielczosci kemerze
/// </summary>
public class CameraResolution : MonoBehaviour
{
    private int ScreenSizeX;
    private int ScreenSizeY;

    private void RescaleCamera()
    {
        if (Screen.width == ScreenSizeX && Screen.height == ScreenSizeY) return;

        var targetaspect = 320f / 512f;
        var windowaspect = Screen.width / (float)Screen.height;
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
        else // add pillarbox
        {
            var scalewidth = 1.0f / scaleheight;

            var rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

        ScreenSizeX = Screen.width;
        ScreenSizeY = Screen.height;
    }

    #region metody unity

    private void OnPreCull()
    {
        if (Application.isEditor) return;
        var wp = Camera.main.rect;
        var nr = new Rect(0, 0, 1, 1);

        Camera.main.rect = nr;
        GL.Clear(true, true, Color.black);

        Camera.main.rect = wp;
    }

    // Use this for initialization
    private void Start()
    {
        RescaleCamera();
    }

    // Update is called once per frame
    private void Update()
    {
        RescaleCamera();
    }

    #endregion
}
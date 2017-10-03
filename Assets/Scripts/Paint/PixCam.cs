using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Paint/PixCam")]
public class PixCam : MonoBehaviour
{
    Texture2D texture2D;
    RenderTexture renderTexture;

    int camPixels = 0;
    int filstCamPixels = 0;

    public int FilstCamPixels
    {
        get { return filstCamPixels; }
        set { filstCamPixels = value; }
    }

    public int CamPixels
    {
        get { return camPixels; }
        set { camPixels = value; }
    }

    int GetPixels()
    {
        texture2D = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        renderTexture = new RenderTexture(texture2D.width, texture2D.height, 24);

        RenderTexture prev = Camera.main.targetTexture;
        Camera.main.targetTexture = renderTexture;
        Camera.main.Render();

        RenderTexture.active = renderTexture;

        texture2D.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture2D.Apply();

        //使い終わったら戻してあげる
        Camera.main.targetTexture = prev;

        Color[] color = texture2D.GetPixels();
        int count = 0;
        for (int i = 0; i < color.Length; i++)
        {
            if (color[i].r == color[i].g && color[i].g == color[i].b)
            {
                count++;
            }
        }
        return count;
    }

    void Start()
    {
        filstCamPixels = GetPixels();
        camPixels = GetPixels();
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            camPixels = GetPixels();
            Debug.Log("グレースケールピクセルの数" + camPixels);
        }
    }
}
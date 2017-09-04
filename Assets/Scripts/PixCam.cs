using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixCam : MonoBehaviour
{
    Texture2D texture2D;
    RenderTexture renderTexture;

    int GetPixel()
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

    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("グレースケールピクセルの数" + GetPixel());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Scripts/Paint/PixCheck")]
public class PixCheck : MonoBehaviour {

    //------------------------------------------------
    // private
    //------------------------------------------------
    //Renderer renderer;

    //Texture2D mainTexture;
    Texture2D texture2D;
    RenderTexture renderTexture;

    Color[] pixels;

    int whitePixels = 0; //現在の白ピクセル数を保存
    int filstWhitePixels = 0; //一番最初の白ピクセルを保存

    //------------------------------------------------
    // プロパティ
    //------------------------------------------------

        //全体の何パーセント塗れているかを渡すプロパティ
    public int PixelsPaint
    {
        get;
        set;
    }

    //==================================================

    void Start ()
    {
        //renderer = GetComponent<Renderer>();
        whitePixelsCheck();
        filstWhitePixels = whitePixels;
    }

    void Update ()
    {
        //３０フレームに一度処理を実行する
        int _framCount = Time.frameCount;

        if(_framCount%30 == 0)
        {
            whitePixelsCheck();
            PixPaint();
        }
    }

    //------------------------------------------------
    // ピクセルの色を調べるメソッド
    //------------------------------------------------
    void whitePixelsCheck()
    {
        //mainTexture = renderer.material.mainTexture as Texture2D;
        //pixels = mainTexture.GetPixels();

        //int whiteCount = 0; //白ピクセル

        //foreach (Color c in pixels)
        //{
        //    if (c == Color.white) whiteCount++;
        //}

        //whitePixels = whiteCount;

        texture2D = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        renderTexture = new RenderTexture(texture2D.width, texture2D.height, 24);

        RenderTexture prev = Camera.main.targetTexture;
        Camera.main.targetTexture = renderTexture;
        Camera.main.Render();

        RenderTexture.active = renderTexture;

        texture2D.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture2D.Apply();

        Camera.main.targetTexture = prev;

        Color[] color = texture2D.GetPixels();
        int whiteCount = 0;

        Debug.Log(color.Length);

        for(int i = 0; i< color.Length; i++)
        {
            if (color[i] == Color.white) whiteCount++;
        }

        //Debug.Log(whiteCount);
        whitePixels = whiteCount;
    }

    //------------------------------------------------
    // 全体の何パーセント塗れたかを調べるメソッド
    //------------------------------------------------
    void PixPaint()
    {
        //パーセンテージを計算
        float p = 0;

        //整数同士の割り算は整数になるので、float型で計算
        p = (float)whitePixels / (float)filstWhitePixels * 100;

        PixelsPaint = 100 - Mathf.FloorToInt(p);
    }
}
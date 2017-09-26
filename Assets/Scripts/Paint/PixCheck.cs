using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Scripts/Paint/PixCheck")]
public class PixCheck : MonoBehaviour {

    //------------------------------------------------
    // private
    //------------------------------------------------

    Texture2D mainTexture;
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
        mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
        pixels = mainTexture.GetPixels();

        int whiteCount = 0; //白ピクセル

        foreach (Color c in pixels)
        {
            if (c == Color.white) whiteCount++;
        }

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
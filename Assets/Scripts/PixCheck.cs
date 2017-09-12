using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixCheck : MonoBehaviour {

    //------------------------------------------------
    // private
    //------------------------------------------------

    Texture2D mainTexture;
    Color[] pixels;

    int whitePixels = 0; //現在の白ピクセル数を保存
    int filstWhitePixels = 0; //一番最初の白ピクセルを保存

    int pixelsPaint = 0; //全体の何パーセント塗れたのか

    //------------------------------------------------
    // プロパティ
    //------------------------------------------------

    //全体の何パーセント塗れているかを渡すプロパティ
    public int PixelsPaint
    {
        get { return pixelsPaint; }
        set { pixelsPaint = value; }
    }

    //==================================================

    void Start ()
    {
        whitePixelsCheck();
        filstWhitePixels = whitePixels;
    }

    void Update ()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            whitePixelsCheck();
            PixPaint();
        }
    }

    //------------------------------------------------
    // 白のピクセルを調べるメソッド
    //------------------------------------------------
    void whitePixelsCheck()
    {
        mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
        pixels = mainTexture.GetPixels();

        int count = 0;

        foreach (Color c in pixels)
        {
            if (c == Color.white)
                count++;
        }

        whitePixels = count;
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

        pixelsPaint = 100 - Mathf.FloorToInt(p);
    }
}
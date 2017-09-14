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
        int _framCount = Time.frameCount;

        if(_framCount%30 == 0)
        {
            whitePixelsCheck();
            PixPaint();
        }

        //if (Input.GetButtonUp("Fire1"))
        //{
        //    whitePixelsCheck();
        //    PixPaint();
        //}
    }

    //------------------------------------------------
    // ピクセルの色を調べるメソッド
    //------------------------------------------------
    void whitePixelsCheck()
    {
        mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
        pixels = mainTexture.GetPixels();

        int whiteCount = 0; //白ピクセル
        //int redCount = 0; //赤ピクセル
        //int blueCount = 0; //青ピクセル
        //int greenCount = 0; //緑ピクセル

        foreach (Color c in pixels)
        {
            if (c == Color.white) whiteCount++;

            //else if (c == Color.red) redCount++;
            //else if (c == Color.blue) blueCount++;
            //else if (c == Color.green) greenCount++;
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

        Debug.Log(p);

        PixelsPaint = 100 - Mathf.FloorToInt(p);
    }
}
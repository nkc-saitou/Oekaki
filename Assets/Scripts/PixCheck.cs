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

    //一番最初の白ピクセルを渡すプロパティ
    public int FilstWhitePixels
    {
        get { return filstWhitePixels; }
        set { filstWhitePixels = value; }
    }

    //現在白ピクセルを渡すプロパティ
    public int WhitePixels
    {
        get { return whitePixels; }
        set { whitePixels = value; }
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
}

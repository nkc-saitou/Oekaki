using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //----------------------------------------------
    // private
    //----------------------------------------------

    PixCam pixCam;

    int filstWhitePixels = 0;
    int whitePixels = 0;

    int pixelsPaint = 0;

    float _framCount;

    //----------------------------------------------
    // public
    //----------------------------------------------

    public int clearBorder = 80;

    public PixCheck pixCheck;

    public GameObject clearImage;


    public static bool ClearFlg = false; //クリア用フラグ　クリア時にtrueにする


    void Start ()
    {
        pixCam = GetComponent<PixCam>();
        clearImage.SetActive(false);
    }
	
	void Update ()
    {
        _framCount = Time.frameCount;

        if(_framCount % 30 == 0)
        {
            PixPaint();
        }
       
        Clear();
    }

    void PixPaint()
    {
        filstWhitePixels = pixCam.FilstCamPixels;
        whitePixels = pixCam.CamPixels;

        //パーセンテージを計算
        float p = 0;

        //整数同士の割り算は整数になるので、float型で計算
        p = (float)whitePixels / (float)filstWhitePixels * 100;

        pixelsPaint = 100 - Mathf.FloorToInt(p);
    }

    void Clear()
    {
        //if (pixelsPaint < clearBorder) return;
        if(pixCheck.PixelsPaint >= 90)
        {
            clearImage.SetActive(true);
            ClearFlg = true;
        }
    }
}
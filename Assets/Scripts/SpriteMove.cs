using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMove : MonoBehaviour {

    //------------------------------------------
    // private
    //------------------------------------------

    PixCheck pixCheck;

    int filstWhitePixsels;
    int whitePixels = 0; //最初の白

    int pixelsPaint; //どれだけ塗れたかのパーセンテージ

    void Start ()
    {
        pixCheck = GetComponent<PixCheck>();
	}
	
	void Update ()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            PixPaint();
        }
	}

    void PixPaint()
    {
        filstWhitePixsels = pixCheck.FilstWhitePixels;
        whitePixels = pixCheck.WhitePixels;

        //パーセンテージを計算
        float p = 0;

        //整数同士の割り算は整数になるので、float型で計算
        p = (float)whitePixels / (float)filstWhitePixsels * 100;

        pixelsPaint = 100 - Mathf.FloorToInt(p);

        Debug.Log(pixelsPaint);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    PixCam pixCam;

    int filstWhitePixels = 0;
    int whitePixels = 0;

    int pixelsPaint = 0;

    void Start ()
    {
        pixCam = GetComponent<PixCam>();
	}
	
	void Update ()
    {
		if(Input.GetButtonUp("Fire1"))
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

        Debug.Log(pixelsPaint);
    }

    void Clear()
    {
        if (pixelsPaint < 97) return;

        Debug.Log("Clear!");
    }
}
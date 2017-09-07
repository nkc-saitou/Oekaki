using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMove : MonoBehaviour {

    //------------------------------------------
    // public
    //------------------------------------------

    public float shakeX;
    public float shakeY;

    //------------------------------------------
    // private
    //------------------------------------------

    PixCheck pixCheck;

    int filstWhitePixsels;
    int whitePixels = 0; //最初の白

    int pixelsPaint; //どれだけ塗れたかのパーセンテージ

    Vector3 objPos;

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

        ShakeSprite();
        MoveSprite();
    }

    //--------------------------------------------------------
    //　どれだけ色が塗れたかのパーセントを調べるメソッド
    //--------------------------------------------------------
    void PixPaint()
    {
        filstWhitePixsels = pixCheck.FilstWhitePixels;
        whitePixels = pixCheck.WhitePixels;

        //パーセンテージを計算
        float p = 0;

        //整数同士の割り算は整数になるので、float型で計算
        p = (float)whitePixels / (float)filstWhitePixsels * 100;

        pixelsPaint = 100 - Mathf.FloorToInt(p);
    }

    //--------------------------------------------------------
    //　震えるメソッド
    //--------------------------------------------------------
    void ShakeSprite()
    {
        if (pixelsPaint < 10 || pixelsPaint >= 70) return;

        objPos = gameObject.transform.localPosition;

        objPos.x -= shakeX;
        objPos.y -= shakeY;
        shakeX *= -1;
        shakeY *= -1;
        objPos.x += shakeX;
        objPos.y += shakeY;

        gameObject.transform.localPosition = objPos;
    }

    void MoveSprite()
    {
        if (pixelsPaint < 70) return;

        float dx = 0;
        float speed = 15.0f;

        float border = 20;

        objPos = gameObject.transform.localPosition;
        dx += speed * Time.deltaTime;
        objPos.x += dx;
        gameObject.transform.localPosition = objPos;

        if(objPos.x > border)
        {
            Destroy(gameObject);
        }
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGimmick : MonoBehaviour {

    //------------------------------------------
    // public
    //------------------------------------------

    public float shakeX = 0.02f;

    //------------------------------------------
    // private
    //------------------------------------------

    [SerializeField]
    SoundManager.SE gimmickSE;

    PixCheck pixCheck;

    int pixelsPaint = 0; //どれだけ塗れたかのパーセンテージ

    Vector3 objPos;

    protected int GimmickAct = 70;

    void Start()
    {
        pixCheck = GetComponent<PixCheck>();
        objPos = transform.localPosition;
    }

    void Update()
    {
        //30フレームに一度塗れているかを判定する
        int _framCount = Time.frameCount;

        if (_framCount % 30 == 0)
        {
            pixelsPaint = pixCheck.PixelsPaint;
        }

        //if (Input.GetButtonUp("Fire1"))
        //{
        //    pixelsPaint = pixCheck.PixelsPaint;
        //}

        ShakeSprite();
        MoveSprite();
    }

    //--------------------------------------------------------
    //　震えるメソッド
    //--------------------------------------------------------
    void ShakeSprite()
    {
        //一定以上塗れている、または一定以上塗れていない場合、以下の処理をしない
        if (pixelsPaint < 5 || pixelsPaint >= GimmickAct) return;

        gameObject.transform.localPosition = new Vector3(objPos.x+Mathf.Sin(Time.time*100) * shakeX,transform.localPosition.y, transform.localPosition.z);
    }

    //--------------------------------------------------------
    //　ギミック発動用メソッド
    //--------------------------------------------------------
    void MoveSprite()
    {
        BorderSetting();

        //一定以上塗れていない場合、ギミックの処理を実行しない
        if (pixelsPaint < GimmickAct) return;

        GimmickActivate();
    }

    //--------------------------------------------------------
    //　どんなギミックが発動するか
    //--------------------------------------------------------
    public virtual void GimmickActivate()
    {
        //オブジェクトを動かす
        float dx = 0;
        float speed = 15.0f;
        float border = -20;

        objPos = gameObject.transform.localPosition;
        dx -= speed * Time.deltaTime;
        objPos.x += dx;
        gameObject.transform.localPosition = objPos;

        //border以上動いたらオブジェクトを削除する
        if (objPos.x < border)
        {
            Destroy(gameObject);
        }

        //音再生
        SoundManager.instance.PlayBack_SE(gimmickSE);
    }

    public virtual void BorderSetting()
    {
        GimmickAct = 70;
    }
}
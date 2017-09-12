using System.Collections;
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

    PixCheck pixCheck;

    int pixelsPaint = 0; //どれだけ塗れたかのパーセンテージ

    Vector3 objPos;


    void Start()
    {
        pixCheck = GetComponent<PixCheck>();
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            pixelsPaint = pixCheck.PixelsPaint;
        }

        ShakeSprite();
        MoveSprite();
    }

    //--------------------------------------------------------
    //　震えるメソッド
    //--------------------------------------------------------
    void ShakeSprite()
    {
        //一定以上塗れている、または一定以上塗れていない場合、以下の処理をしない
        if (pixelsPaint < 10 || pixelsPaint >= 70) return;

        objPos = gameObject.transform.localPosition;

        //ｘ軸方向にぶるぶる震える
        objPos.x -= shakeX;
        shakeX *= -1;
        objPos.x += shakeX;

        gameObject.transform.localPosition = objPos;
    }

    //--------------------------------------------------------
    //　ギミック発動用メソッド
    //--------------------------------------------------------
    void MoveSprite()
    {
        //一定以上塗れていない場合、ギミックの処理を実行しない
        if (pixelsPaint < 70) return;

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
        float border = 20;

        objPos = gameObject.transform.localPosition;
        dx += speed * Time.deltaTime;
        objPos.x += dx;
        gameObject.transform.localPosition = objPos;

        //border以上動いたらオブジェクトを削除する
        if (objPos.x > border)
        {
            Destroy(gameObject);
        }
    }
}

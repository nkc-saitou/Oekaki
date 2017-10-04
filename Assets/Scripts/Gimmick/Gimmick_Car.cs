using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Car : BaseGimmick {

    Vector3 startPos;
    float vertical;
    float horizontal;

    void Start()
    {
        base.Start();

        startPos = gameObject.transform.position;
        vertical = startPos.y * 5;
        vertical *= -1;
    }

    //--------------------------------------------------------
    //　どんなギミックが発動するか
    //--------------------------------------------------------
    public override void OneActivate()
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

    public override void TwoActivate()
    {
        
    }

    public override void ThreeActivate()
    {

    }
}
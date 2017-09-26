using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Gimmick/Flower")]
public class Flower : MonoBehaviour {

    public GameObject block;
    Vector3 offset;
    Vector3 target;
    float speed = 10.0f;
    float rad;

    bool filstFlg = true;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 10));
        flowerMove();
    }

    void flowerMove()
    {
        //ラジアン計算
        // atan2(目標方向のy座標 - 初期位置のy座標, 目標方向のx座標 - 初期位置のx座標)
        rad = Mathf.Atan2(
            block.transform.localPosition.y - gameObject.transform.localPosition.y,
            block.transform.localPosition.x - gameObject.transform.localPosition.x);

        //現在のオブジェクトの位置を代入
        offset = gameObject.transform.localPosition;

        //x += SPEED * cos(ラジアン)
        // y += SPEED * sin(ラジアン)
        offset.x += speed * Time.deltaTime * Mathf.Cos(rad);
        offset.y += speed * Time.deltaTime * Mathf.Sin(rad);

        //現在の位置へ計算した値を代入する
        gameObject.transform.localPosition = offset;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Esa")
        {
            Destroy(gameObject);
        }
    }

}

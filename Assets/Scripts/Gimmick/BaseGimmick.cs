using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Gimmick/BaseGimmick")]
public class BaseGimmick : MonoBehaviour {

    //------------------------------------------
    // public
    //------------------------------------------

    public float shakeX = 0.02f;

    //------------------------------------------
    // private
    //------------------------------------------

    [SerializeField]
    protected SoundManager.SE gimmickSE;

    PixCheck pixCheck;

    int pixelsPaint = 0; //どれだけ塗れたかのパーセンテージ

    protected Vector3 objPos;

    protected int gimmickAct = 70;

    bool actFlg = false;

    enum ColorState
    {
        one,
        two,
        three
    }

    ColorState colorState;

    protected void Start()
    {
        pixCheck = gameObject.GetComponent<PixCheck>();
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
        if(!Input.GetMouseButton(0)) MoveSprite();
    }

    //--------------------------------------------------------
    //　震えるメソッド
    //--------------------------------------------------------
    void ShakeSprite()
    {
        //一定以上塗れている、または一定以上塗れていない場合、以下の処理をしない
        if (pixelsPaint < 5 || pixelsPaint >= gimmickAct) return;

        gameObject.transform.localPosition = new Vector3(objPos.x+Mathf.Sin(Time.time*100) * shakeX,transform.localPosition.y, transform.localPosition.z);
    }

    //--------------------------------------------------------
    //　ギミック発動用メソッド
    //--------------------------------------------------------
    void MoveSprite()
    {
        //一定以上塗れていない場合、ギミックの処理を実行しない
        if (pixelsPaint < gimmickAct) return;

        ColorPaintKind();
    }

    //--------------------------------------------------------
    //　塗られている色の種類を調べ、それぞれの挙動を実行させるメソッド
    //--------------------------------------------------------
    void ColorPaintKind()
    {
        bool filstFlg = false;

        if (filstFlg) return;

        //int paintKind = 0;

        //if (pixCheck.RedFlg) paintKind++;
        //if (pixCheck.GreenFlg) paintKind++;
        //if (pixCheck.BlueFlg) paintKind++;

        //switch(paintKind)
        //{
        //    case 1:
        //        OneActivate();
        //        break;

        //    case 2:
        //        TwoActivate();
        //        break;

        //    case 3:
        //        ThreeActivate();
        //        break;
        //}
        OneActivate();
        filstFlg = true;
    }

    //--------------------------------------------------------
    //　どんなギミックが発動するか
    //--------------------------------------------------------
    public virtual void OneActivate()
    {
        //処理継承先で書く

    }

    public virtual void TwoActivate()
    {
        //処理継承先で書く

    }

    public virtual void ThreeActivate()
    {
        //処理継承先で書く

    }
}
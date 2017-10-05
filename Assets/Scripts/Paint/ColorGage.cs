using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Es.InkPainter.Sample;

[RequireComponent(typeof(Animator))]
[AddComponentMenu("Scripts/Paint/ColorGage")]
public class ColorGage : MonoBehaviour
{
    const float GAGE_WIDTH_MAX = 42;

    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    //Titleフラグ
    [SerializeField]
    bool titleFlg;

    [SerializeField]
    GameObject gameOverImage;
    [SerializeField, Space]
    RectTransform[] gages = new RectTransform[3];
    [SerializeField]
    InkPut inkPut;

    Animator animator;

    //false:残量有, true:残量無
    bool[] gagesFlg = { false, false, false };

    //選択中の色
    PaintColor selectTube = PaintColor.Red;

    //ポインターがボタン上にあるかどうか
    bool flg = false;

    string[] parametars = { "DownRed", "DownGreen", "DownBlue", "CancelRed", "CancelGreen", "CancelBlue", "UpRed", "UpGreen", "UpBlue" };

    //=========================================================================
    void Start()
    {
        animator = GetComponent<Animator>();
        
        if(gameOverImage != null)
            gameOverImage.SetActive(false);
    }
    //-------------------------------------------------------------------------
    //  ゲージ減少
    //-------------------------------------------------------------------------
    public void GageDown(int color, float scale)
    {
        if (titleFlg) return;
        //ゲージ変動
        Vector2 size = gages[color].sizeDelta;
        size.x = Mathf.Max(0, size.x - (Time.deltaTime * scale));
        gages[color].sizeDelta = size;

        //空になったら
        if (size.x == 0)
        {
            gagesFlg[color] = true;
            //ペンを使用不可に
            MousePainter.isBrushUse = false;
            //パレットを空に
            inkPut.EmptyColor();

            if (gagesFlg[0] && gagesFlg[1] && gagesFlg[2])
                GameOver();
        }
    }
    //-------------------------------------------------------------------------
    //  ゲージ回復
    //-------------------------------------------------------------------------
    public void GageHeal(int color)
    {
        //ゲージ全回復
        Vector2 size = gages[color].sizeDelta;
        size.x = GAGE_WIDTH_MAX;
        gages[color].sizeDelta = size;

        //フラグをリセット
        gagesFlg[color] = false;
    }
    //-------------------------------------------------------------------------
    //  ゲームオーバー
    //-------------------------------------------------------------------------
    void GameOver()
    {
        //Debug.Log("GameOver");
        //return;

        if (GameManager.instance.ClearFlg) return;
        //ゲームオーバーイメージの表示

        SceneOption.Instance.TransitionScene("SelectScene",2.0f);
        GameManager.instance.GameOver();
        gameOverImage.SetActive(true);
    }

    //-------------------------------------------------------------------------
    //  Event
    //-------------------------------------------------------------------------
    public void DownTube(string tube)
    {
        if (Time.timeScale <= 0) return;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle@Tube")) return;

        //ペンを使用不可に
        MousePainter.isBrushUse = false;
        //文字列をEnumに
        if (tube == PaintColor.Red.ToString()) selectTube = PaintColor.Red;
        else if (tube == PaintColor.Green.ToString()) selectTube = PaintColor.Green;
        else if (tube == PaintColor.Blue.ToString()) selectTube = PaintColor.Blue;

        //アニメーション
        string trigger = "Down" + tube;
        animator.SetTrigger(trigger);
    }
    public void UpTube()
    {
        if (Time.timeScale <= 0) return;

        //アニメーション
        string trigger = (flg) ? "Up" : "Cancel";
        trigger += selectTube.ToString();
        animator.SetTrigger(trigger);
    }
    public void EnterTube() { flg = true; }
    public void ExitTzube() { flg = false; }

    //-------------------------------------------------------------------------
    //  Animation
    //-------------------------------------------------------------------------
    public void ChangeColor()
    {
        if (gagesFlg[(int)selectTube]) return;

        //ペンを使用可能に
        MousePainter.isBrushUse = true;
        //ペンに色を反映
        MousePainter.brushColor = selectTube;

        //効果音
        SoundManager.instance.PlayBack_SE(SoundManager.SE.Ink);
        //インクをパレットにセット
        inkPut.SetColor((int)selectTube);

        //トリガーをリセット
        ResetTrigger();
    }

    //----------------------------------------------------------------------------
    //　＼　　　　　　　　　　　　　　　　　　　　/
    //　　 ＼　　丶　　　　 　 i.　　 |　　　　　 /　　 　 ./　　　　 　 ／
    //　　　　＼　　ヽ　　　　　i. 　 .|　　　　　/　　　 /　　　　　 ／
    //　　　　　 ＼　　ヽ　　　　i　　|　　　　 /　　　/　　　　　／
    //　　　＼
    //　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　-‐
    //　　ー
    //　_＿　　　　　　　　　　わ　た　し　で　す　　　　　　　　　　　　--
    //　　　　　二　　　　　　　 　　／￣＼　　　　　　　　　　　＝　二
    //　　￣　　　　　　　　　　　　|＾o＾ |　　　　　　　　　　　　　　　　￣
    //　　　　-‐　　　　　　　　　  ＼＿／ 　　　　　　　　　　　　　　　‐-
    //
    //　　　　／
    //　　　　　　　　　　　　/　　　　　　　　　　　　　　　ヽ　　　　　 ＼
    //　　　　／　　　　　　　　　　　　　　　　　　　　丶　　　　 ＼
    //　　 ／　　　/　　　 /　　　　　　|　　　i,　　　 　 丶　　　　　＼
    //　／　　　 /　　　　/　　　　　　 |　　　 i,　　　　　　丶　　　　　＼
    //----------------------------------------------------------------------------
    public void ResetTrigger()
    {
        for (int i = 0; i < parametars.Length; i++)
        {
            animator.ResetTrigger(parametars[i]);
        }
    }
}
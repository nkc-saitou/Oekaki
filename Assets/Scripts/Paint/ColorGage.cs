using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Scripts/Paint/ColorGage")]
public class ColorGage : MonoBehaviour
{
    const int GAGE_MAX = 300;

    public GameObject gameOverImage;

    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    [SerializeField]
    PenData data;

    [SerializeField]
    RectTransform colorGages;   //ゲージの親オブジェクト
    [SerializeField]
    RectTransform gageSample;

    Color[] penColorArr = new Color[10];    //ペンの色の種類
    int[] penGageNum = new int[10];     //インク量
    List<RectTransform> gageArr = new List<RectTransform>();

    //=========================================================================

    void Start()
    {
        //データを取得
        data.colorArr.CopyTo(penColorArr, 0);
        data.colorNumArr.CopyTo(penGageNum, 0);

        gameOverImage.SetActive(false);

        //ゲージ量
        int gageCnt = 0;

        for (int i = 0; i < data.colorArr.Length; i++)
        {
            //生成
            RectTransform gage = Instantiate(gageSample);
            gage.SetParent(colorGages);
            gage.SetAsFirstSibling();

            //大きさと位置を調整
            gage.localPosition = new Vector3(0, 0, 0);
            gage.sizeDelta = new Vector2(30, (penGageNum[i] + gageCnt) * GAGE_MAX * 0.01f);
            gageCnt += penGageNum[i];

            //ゲージの色を設定
            gage.GetComponent<Image>().color = penColorArr[i];

            //配列に追加
            gageArr.Add(gage);
        }
        ChangeColor();
    }

    //-------------------------------------------------------------------------
    //  ペン変更
    //-------------------------------------------------------------------------

    void ChangeColor()
    {
        //ペンの色変更
        PixAcces.penColor = penColorArr[0];
        PixAcces.isPenUse = (penGageNum[0] != 0);
    }

    //-------------------------------------------------------------------------
    //  ゲージ減少
    //-------------------------------------------------------------------------

    public void GageDown()
    {
        //ゲージ消費
        penGageNum[0]--;

        //ゲージに反映
        foreach (RectTransform gage in gageArr)
        {
            Vector2 size = gage.sizeDelta;
            size.y -= GAGE_MAX * 0.01f;
            gage.sizeDelta = size;
        }

        //残量確認--------------------------------------------
        if (penGageNum[0] != 0) return;
        if (gageArr.Count == 1)
        {
            GameOver();
            return;
        }

        //前詰め
        for (int i = 0; i < gageArr.Count - 1; i++)
        {
            penColorArr[i] = penColorArr[i + 1];
            penGageNum[i] = penGageNum[i + 1];
        }
        //後処理
        penColorArr[gageArr.Count - 1] = Color.black;
        penGageNum[gageArr.Count - 1] = 0;
        //先頭ゲージを削除
        Destroy(gageArr[0].gameObject);
        gageArr.Remove(gageArr[0]);

        //ペン変更
        ChangeColor();
    }

    //-------------------------------------------------------------------------
    //  ゲージ回復
    //-------------------------------------------------------------------------
    public void GageHeal(Color color, int num)
    {
        //色確認
        if (penColorArr[gageArr.Count - 1] == color)    //回復する色が最後尾の色だった場合
        {
            penGageNum[gageArr.Count - 1] += num;
            Vector2 size = gageArr[gageArr.Count - 1].sizeDelta;
            size.y += num * GAGE_MAX * 0.01f;
            gageArr[gageArr.Count - 1].sizeDelta = size;
        }
        else   //回復する色が最後尾の色でなかった場合
        {
            //合計
            int height = 0;
            foreach (int ht in penGageNum)
                height += ht;
            //配列の最後尾に追加
            penGageNum[gageArr.Count] += num;
            penColorArr[gageArr.Count] = color;

            //生成
            RectTransform gage = Instantiate(gageSample);
            gage.SetParent(colorGages);
            gage.SetAsFirstSibling();

            //大きさと位置を調整
            gage.localPosition = new Vector3(0, 0, 0);
            gage.sizeDelta = new Vector2(30, (penGageNum[gageArr.Count] + height) * GAGE_MAX * 0.01f);

            //ゲージの色を設定
            gage.GetComponent<Image>().color = color;

            //配列に追加
            gageArr.Add(gage);
        }
    }

    //-------------------------------------------------------------------------
    //  ゲームオーバー
    //-------------------------------------------------------------------------
    void GameOver()
    {
        PixAcces.isPenUse = false;
        gameOverImage.SetActive(true);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Scripts/Paint/ColorGage")]
public class ColorGage : MonoBehaviour
{
    //public static ColorGage instance;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(this.gameObject);
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    [SerializeField]
    Color[] penColorArr;    //ペンの色の種類

    int[] penGageNum;

    [SerializeField]
    Button[] colorBtn;      //色変更ボタン
    [SerializeField]
    RectTransform[] gageArr;  //ゲージ量

    int selectNo;   //現在の番号

    float timer = 0;
	
    //=========================================================================

	void Start ()
    {
        //ゲージ量
        penGageNum = new int[penColorArr.Length];

        for (int i = 0; i < penColorArr.Length; i++)
        {
            //Buttonの色を設定
            ColorBlock colors = new ColorBlock();
            colors.normalColor = penColorArr[i];
            colors.highlightedColor = penColorArr[i];
            colors.pressedColor = penColorArr[i];
            colors.colorMultiplier = 1;
            colorBtn[i].colors = colors;

            //ゲージ
            penGageNum[i] = 100;
        }
        ChangeColor(0);
	}

    //-------------------------------------------------------------------------
    //  Button
    //-------------------------------------------------------------------------

    public void ChangeColor(int colorNo)
    {
        selectNo = colorNo;
        //ペンの色変更
        PixAcces.penColor = penColorArr[colorNo];
        PixAcces.isPenUse = (penGageNum[colorNo] != 0);

        timer = 0;
    }

    public void ChangeCollection()
    {
        selectNo = -1;
        //ペンの色変更
        PixAcces.penColor = Color.white;
        PixAcces.isPenUse = true;
        PixAcces.gageCount = 0;
    }

    //-------------------------------------------------------------------------
    //  ゲージ減少
    //-------------------------------------------------------------------------

    public void GageDown()
    {
        //ゲージ消費
        penGageNum[selectNo] = Mathf.Max(0, penGageNum[selectNo] - 1);
        gageArr[selectNo].sizeDelta = new Vector2(penGageNum[selectNo], 20);

        //残量確認
        if (penGageNum[selectNo] == 0)
            PixAcces.isPenUse = false;
    }

    //-------------------------------------------------------------------------
    //  ゲージ回復
    //-------------------------------------------------------------------------
    public void GageHeal(int select,int num)
    {
        //ゲージ回復
        penGageNum[select] = Mathf.Min(100, penGageNum[select] + num);
    }

    //-------------------------------------------------------------------------
    //  残りゲージの確認
    //-------------------------------------------------------------------------
    void CheckGage()
    {

    }
}
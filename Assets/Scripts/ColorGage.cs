using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Scripts/Paint/ColorGage")]
public class ColorGage : MonoBehaviour
{
    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    [SerializeField]
    Color[] penColorArr = new Color[10];    //ペンの色の種類
    [SerializeField]
    int[] penGageNum = new int[10];

    [SerializeField]
    RectTransform[] gageArr;  //ゲージ量
	
    //=========================================================================

	void Start ()
    {
        //ゲージ量
        penGageNum = new int[penColorArr.Length];

        for (int i = 0; i < penColorArr.Length; i++)
        {
            ////Buttonの色を設定
            //ColorBlock colors = new ColorBlock();
            //colors.normalColor = penColorArr[i];
            //colors.highlightedColor = penColorArr[i];
            //colors.pressedColor = penColorArr[i];
            //colors.colorMultiplier = 1;

            //ゲージ
            penGageNum[i] = 100;
        }

        ChangeColor();
	}

    //-------------------------------------------------------------------------
    //  Button
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
        for(int i = 0; i < penGageNum.Length; i++)
        {
            if (penGageNum[i] == 0) break;

            penGageNum[i]--;
        }
        //penGageNum[selectNo] = Mathf.Max(0, penGageNum[selectNo] - 1);
        //gageArr[selectNo].sizeDelta = new Vector2(penGageNum[selectNo], 20);

        //残量確認
        if(penGageNum[0] == 0)
        {
            
        }
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
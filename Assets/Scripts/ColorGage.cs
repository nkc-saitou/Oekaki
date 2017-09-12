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

    void Update()
    {
        if (Input.GetMouseButton(0) && penGageNum[selectNo] != 0)
        {
            timer += Time.deltaTime;

            if(timer >= 0.2f)
            {
                //ゲージ減少
                penGageNum[selectNo]--;
                gageArr[selectNo].sizeDelta = new Vector2(penGageNum[selectNo], 20);
                timer = 0;

                if (penGageNum[selectNo] == 0)
                    PixAcces.isPenUse = false;
                    
            }
        }
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
        
    }

    //-------------------------------------------------------------------------
    //  ゲージ回復
    //-------------------------------------------------------------------------

    public void GageHeal(int select,int num)
    {
        //ゲージ回復
        penGageNum[select] = Mathf.Max(100, penGageNum[select] + num);
    }
}

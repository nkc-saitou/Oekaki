using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorGage : MonoBehaviour
{
    [SerializeField]
    Color[] penColorArr;

    [SerializeField]
    Button[] colorBtn;
	
	void Start ()
    {
        for(int i = 0; i < penColorArr.Length; i++)
        {
            //Buttonの色を設定
            ColorBlock colors = new ColorBlock();
            colors.normalColor = penColorArr[i];
            colors.highlightedColor = penColorArr[i];
            colors.pressedColor = penColorArr[i];
            colors.colorMultiplier = 1;
            colorBtn[i].colors = colors;
        }

        ChangeColor(0);
	}
	
    public void ChangeColor(int colorNo)
    {
        //ペンの色変更
        PixAcces.penColor = penColorArr[colorNo];
    }
}

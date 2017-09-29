using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Paint/InkPut")]
public class InkPut : MonoBehaviour
{
    const float INKSIZE_MAX = 1.0f;

    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    [SerializeField]
    RectTransform[] inks;   //0:Red, 1:Green, 2:Blue

    int selectColor = -1;

    bool IsPut = false;

    //=========================================================================
	void Update ()
    {
        //色の変化
        if (IsPut) ColorChangeMove();
	}
    //-------------------------------------------------------------------------
    //  色を変更
    //-------------------------------------------------------------------------
    public void SetColor(string color)
    {
        //番号に変換
        int colorNo = 0;
        if (color == "Red") colorNo = 0;
        else if (color == "Green") colorNo = 1;
        else if (color == "Blue") colorNo = 2;

        if (selectColor == colorNo) return;
        else selectColor = colorNo;

        //準備
        inks[selectColor].gameObject.SetActive(true);
        inks[selectColor].localScale = new Vector3(0, 0, 0);
        inks[selectColor].SetAsLastSibling();
        IsPut = true;
    }
    void ColorChangeMove()
    {
        //拡大
        float upScale = inks[selectColor].localScale.x;
        upScale = Mathf.Min(INKSIZE_MAX, upScale + Time.deltaTime * 3);
        inks[selectColor].localScale = new Vector3(upScale, upScale, upScale);

        //Scaleを確認
        if (upScale == INKSIZE_MAX) IsPut = false;
    }
}

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

    int selectColor = 0;

    bool isPut = false;
    bool isEmpty = false;

    //=========================================================================
	void Update ()
    {
        //色の変化
        if (isPut) ColorChangeMove();
        if (isEmpty) ColorEmptyMove();
	}
    //-------------------------------------------------------------------------
    //  色を変更
    //-------------------------------------------------------------------------
    public void SetColor(int colorNo)
    {
        if (selectColor == colorNo) return;
        else selectColor = colorNo;

        //準備
        inks[selectColor].gameObject.SetActive(true);
        inks[selectColor].localScale = new Vector3(0, 0, 0);
        inks[selectColor].SetAsLastSibling();
        isPut = true;
    }
    void ColorChangeMove()
    {
        //拡大
        float upScale = inks[selectColor].localScale.x;
        upScale = Mathf.Min(INKSIZE_MAX, upScale + Time.deltaTime * 3);
        inks[selectColor].localScale = new Vector3(upScale, upScale, upScale);

        //Scaleを確認
        if (upScale == INKSIZE_MAX) isPut = false;
    }
    //-------------------------------------------------------------------------
    //  空になった場合
    //-------------------------------------------------------------------------
    public void EmptyColor()
    {
        isEmpty = true;
    }
    void ColorEmptyMove()
    {
        //縮小
        float downScale = inks[selectColor].localScale.x;
        downScale = Mathf.Max(0, downScale - Time.deltaTime * 3);
        inks[selectColor].localScale = new Vector3(downScale, downScale, downScale);

        //Scaleを確認
        if (downScale == 0) isEmpty = false;
    }
}

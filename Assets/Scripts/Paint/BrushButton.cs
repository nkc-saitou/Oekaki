using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter.Sample;

[AddComponentMenu("Scripts/Paint/BrushButton")]
public class BrushButton : MonoBehaviour
{
    const float MOVEMENT = 100.0f;

    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    [SerializeField]
    RectTransform[] brushs = new RectTransform[3];  //0:L, 1:M, 2:S
    float[] brushScales = { 0.2f, 0.1f, 0.05f };

    //筆の番号
    int selectNo = 1;
    int beforeNo;

    //動くフラグ
    bool isMove;
    //合計移動量
    float moveSum = 0;

    //=========================================================================
	void Update ()
    {
        //動作
        if (isMove) BrushMove();
	}
    //-------------------------------------------------------------------------
    //  筆の動き
    //-------------------------------------------------------------------------
    void BrushMove()
    {
        //動き
        Vector3 movePosBack = brushs[selectNo].localPosition;
        Vector3 movePosFront = brushs[beforeNo].localPosition;
        float value = Mathf.Lerp(0, MOVEMENT - moveSum, 0.2f);
        moveSum += value;
        movePosBack.x = Mathf.Max(-MOVEMENT, movePosBack.x - value);
        movePosFront.x = Mathf.Min(0, movePosFront.x + value);

        //反映
        brushs[selectNo].localPosition = movePosBack;
        brushs[beforeNo].localPosition = movePosFront;

        //確認
        if (moveSum >= MOVEMENT - 1) isMove = false;
    }
    //-------------------------------------------------------------------------
    //  筆を変更
    //-------------------------------------------------------------------------
    public void ChangeBrush(int brushNo)
    {
        if (Time.timeScale <= 0 || isMove) return;
        //番号
        beforeNo = selectNo;
        selectNo = brushNo;
        moveSum = 0;
        //BrushのScaleを変更
        MousePainter.brushScale = brushScales[selectNo];
        //フラグをtrueに
        isMove = true;
    }
}

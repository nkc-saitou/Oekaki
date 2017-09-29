using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Scripts/Paint/ColorGage")]
public class ColorGage : MonoBehaviour
{
    public GameObject gameOverImage;

    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    //=========================================================================
    void Start()
    {
        gameOverImage.SetActive(false);
    }
    //-------------------------------------------------------------------------
    //  ペン変更
    //-------------------------------------------------------------------------
    void ChangeColor()
    {
        
    }
    //-------------------------------------------------------------------------
    //  ゲージ減少
    //-------------------------------------------------------------------------
    public void GageDown()
    {
    }
    //-------------------------------------------------------------------------
    //  ゲージ回復
    //-------------------------------------------------------------------------
    public void GageHeal(Color color, int num)
    {
    }

    //-------------------------------------------------------------------------
    //  ゲームオーバー
    //-------------------------------------------------------------------------
    void GameOver()
    {
        //ペンを使えなく
        TouchManager.instance.IsTouch(false);

        if (GameManager.instance.ClearFlg) return;
        //ゲームオーバーイメージの表示
        GameManager.instance.GameOver();
        gameOverImage.SetActive(true);
    }
}
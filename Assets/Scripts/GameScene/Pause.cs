using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Es.InkPainter.Sample;

[AddComponentMenu("Scripts/GameScene/Pause")]
public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject menu;

    [SerializeField, Space]
    Sprite[] pauseBtn = new Sprite[2]; //0:再生, 1:停止

    Image image;
    bool isPause = false;

    //=========================================================================
    void Start()
    {
        image = GetComponent<Image>();
    }
    //-------------------------------------------------------------------------
    //  Event
    //-------------------------------------------------------------------------
    public void PauseButton()
    {
        //切り替え
        MousePainter.isBrushUse = isPause;
        isPause = !isPause;
        menu.SetActive(isPause);

        if(isPause) //停止
        {
            Time.timeScale = 0;
            //Button差し替え
            image.sprite = pauseBtn[0];
        }
        else        //再生
        {
            Time.timeScale = 1.0f;
            //Button差し替え
            image.sprite = pauseBtn[1];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter.Sample;

[AddComponentMenu("Scripts/GameScene/Pause")]
public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject menu;

    bool isPause = false;

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
        }
        else        //再生
        {
            Time.timeScale = 1.0f;
        }
    }
}

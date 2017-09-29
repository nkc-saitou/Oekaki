using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Es.InkPainter.Sample;

[RequireComponent(typeof(Animator))]
[AddComponentMenu("Scripts/Paint/TubeController")]
public class TubeController : MonoBehaviour
{
    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------
    [SerializeField]
    InkPut inkPut;

    Animator animator;

    string selectTube = null;
    bool flg = false;

    string[] parametars = { "DownRed", "DownGreen", "DownBlue", "CancelRed", "CancelGreen", "CancelBlue", "UpRed", "UpGreen", "UpBlue" };

    //=========================================================================
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    //-------------------------------------------------------------------------
    //  Event
    //-------------------------------------------------------------------------

    public void DownTube(string tube)
    {
        //ペンを使用不可に
        MousePainter.isBrushUse = false;

        selectTube = tube;
        string trigger = "Down" + tube;
        animator.SetTrigger(trigger);
    }

    public void UpTube(string tube)
    {
        //ペンを使用可能に
        MousePainter.isBrushUse = true;

        string trigger = (flg) ? "Up" : "Cancel";
        trigger += tube;
        animator.SetTrigger(trigger);
    }

    public void EnterTube() { flg = true; }
    public void ExitTube() { flg = false; }

    //-------------------------------------------------------------------------
    //  Animation
    //-------------------------------------------------------------------------
    public void ChangeColor()
    {
        //効果音
        SoundManager.instance.PlayBack_SE(SoundManager.SE.Ink);
        //インクをパレットにセット
        inkPut.SetColor(selectTube);
        //ペンに色を反映
        Color color = Color.white;
        if (selectTube == "Red") color = Color.red;
        else if (selectTube == "Green") color = Color.green;
        else if (selectTube == "Blue") color = Color.blue;
        MousePainter.brushColor = color;

        ResetTrigger();
    }

    public void ResetTrigger()
    {
        for(int i = 0; i < parametars.Length; i++)
        {
            animator.ResetTrigger(parametars[i]);
        }

        selectTube = null;
    }
}
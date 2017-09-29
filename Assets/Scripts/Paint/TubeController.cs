using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        selectTube = tube;
        string trigger = "Down" + tube;
        animator.SetTrigger(trigger);
    }

    public void UpTube(string tube)
    {
        string trigger = "Up" + tube;
        animator.SetTrigger(trigger);
    }

    public void CancelTube(string tube)
    {
        if (selectTube == null) return;

        string trigger = "Cancel" + tube;
        animator.SetTrigger(trigger);
    }
    //-------------------------------------------------------------------------
    //  Animation
    //-------------------------------------------------------------------------

    public void ChangeColor()
    {
        //効果音
        SoundManager.instance.PlayBack_SE(SoundManager.SE.Ink);

        //インクをセット
        inkPut.SetColor(selectTube);

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

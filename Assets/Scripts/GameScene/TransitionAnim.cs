using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter.Sample;

[AddComponentMenu("Scripts/GameScene/TransitionAnim")]
public class TransitionAnim : MonoBehaviour
{
    string nextSceneName;

    //=========================================================================
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //-------------------------------------------------------------------------
    //  Public
    //-------------------------------------------------------------------------
    public void SetNextSceneName(string name)
    {
        nextSceneName = name;
    }
    //-------------------------------------------------------------------------
    //  Animation
    //-------------------------------------------------------------------------
    public void MoveSound()
    {
        //効果音
        SoundManager.instance.PlayBack_SE(SoundManager.SE.TransitionPen);
    }
    public void NextScene()
    {
        //シーン遷移
        if(nextSceneName != null)
            SceneOption.Instance.LoadScene(nextSceneName);
    }
    public void FinishAnim()
    {
        //準備
        MousePainter.isBrushUse = true;
        //削除
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/GameScene/Menu")]
public class Menu : MonoBehaviour
{
    bool firstFlg = false;

    //-------------------------------------------------------------------------
    //  Event
    //-------------------------------------------------------------------------
    public void GameReset()
    {
        if (firstFlg) return;
        firstFlg = true;
        //準備
        Time.timeScale = 1.0f;
        //シーン遷移
        string sceneName = SceneOption.Instance.GetSceneName();
        SceneOption.Instance.TransitionScene(sceneName);
    }

    public void ToSelect()
    {
        if (firstFlg) return;
        firstFlg = true;
        //準備
        Time.timeScale = 1.0f;
        //シーン遷移
        SceneOption.Instance.TransitionScene("SelectScene");
    }
}

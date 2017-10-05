using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Manager/GameManager")]
public class GameManager : MonoBehaviour
{
    //シングルトン
    public static GameManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    //-------------------------------------------------------------------------
    // private
    //-------------------------------------------------------------------------

    bool clearFlg = false;
    bool gameOverFlg = false;

    bool waitFlg = false;

    //-------------------------------------------------------------------------
    // プロパティ
    //-------------------------------------------------------------------------
    public bool ClearFlg
    {
        get { return clearFlg; }
    }
    public bool GameOverFlg
    {
        get { return gameOverFlg; }
    }

    //=========================================================================

    void Update()
    {
        if (clearFlg == false && gameOverFlg == false) return;
        if (waitFlg) return;

        //if (Input.GetMouseButtonDown(0))
        //{
        //    //SceneOption.Instance.LoadScene("SelectScene");
        //    //BGM切り替え
        //    SoundManager.instance.PlayBack_BGM(SoundManager.BGM.TitleSelect);
        //}
    }

    //-------------------------------------------------------------------------
    //  Public
    //-------------------------------------------------------------------------
    public void Clear()
    {
        if (gameOverFlg) return;
        clearFlg = true;
        //音再生
        SoundManager.instance.PlayBack_SE(SoundManager.SE.Clear);
        StartCoroutine(WaitTime(2.0f));
    }
    public void GameOver()
    {
        if (clearFlg) return;
        gameOverFlg = true;
        //音再生
        SoundManager.instance.PlayBack_SE(SoundManager.SE.GameOver);
        //待つ
        StartCoroutine(WaitTime(2.0f));
    }

    public void GameSet()
    {
        clearFlg = false;
        gameOverFlg = false;
        TouchManager.instance.IsTouch(true);
    }
    //-------------------------------------------------------------------------
    //  Wait
    //-------------------------------------------------------------------------
    IEnumerator WaitTime(float time)
    {
        waitFlg = true;
        yield return new WaitForSeconds(time);
        waitFlg = false;
        SoundManager.instance.PlayBack_BGM(SoundManager.BGM.TitleSelect);
    }
}
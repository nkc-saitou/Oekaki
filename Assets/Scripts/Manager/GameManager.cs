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

    //-------------------------------------------------------------------------
    //  Public
    //-------------------------------------------------------------------------
    public void Clear()
    {
        if (gameOverFlg) return;
        clearFlg = true;
    }
    public void GameOver()
    {
        if (clearFlg) return;
        gameOverFlg = true;
    }

    public void GameSet()
    {
        clearFlg = false;
        gameOverFlg = false;
        TouchManager.instance.IsTouch(true);
    }

    void Update()
    {
        if (clearFlg == false && gameOverFlg == false) return;

        if(Input.GetMouseButtonDown(0))
        {
            SceneOption.Instance.LoadScene("SelectScene", 1);
            //BGM切り替え
            SoundManager.instance.PlayBack_BGM(SoundManager.BGM.TitleSelect);
        }
    }
}
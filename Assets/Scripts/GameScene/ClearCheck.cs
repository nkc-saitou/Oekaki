using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/GameScene/ClearCheck")]
public class ClearCheck : MonoBehaviour
{
    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    [SerializeField]
    GameObject clearImage;

    PixCam pixCam;

    //=========================================================================
    void Start()
    {
        //クリア画像を非表示
        clearImage.SetActive(false);

        pixCam = GetComponent<PixCam>();
    }

    void Update()
    {
        if (GameManager.instance.ClearFlg) return;
        if (GameManager.instance.GameOverFlg) return;

        //クリア判定
        if (IsClear()) Clear();
    }
    //-------------------------------------------------------------------------
    //  Clear
    //-------------------------------------------------------------------------
    bool IsClear()
    {
        return pixCam.PixelsPaint >= 90;
    }
    void Clear()
    {
        SceneOption.Instance.TransitionScene("SelectScene", 2.0f);
        GameManager.instance.Clear();
        clearImage.SetActive(true);
    }
}
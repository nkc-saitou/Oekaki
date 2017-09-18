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

    PixCheck pixCheck;

    //=========================================================================
    void Start()
    {
        //クリア画像を非表示
        clearImage.SetActive(false);

        pixCheck = GetComponent<PixCheck>();
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
        return pixCheck.PixelsPaint >= 90;
    }
    void Clear()
    {
        GameManager.instance.Clear();
        clearImage.SetActive(true);
    }
}

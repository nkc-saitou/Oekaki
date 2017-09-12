using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    //シングルトン
    public static TouchManager instance;

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
        }
    }

    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    bool isTouch = true;

    //=========================================================================

    void Update()
    {
        if(isTouch && Input.GetMouseButton(0))
        {

        }
    }

    //-------------------------------------------------------------------------
    //  有効・無効
    //-------------------------------------------------------------------------

    public void IsTouch(bool flg)
    {
        isTouch = flg;
    }
}

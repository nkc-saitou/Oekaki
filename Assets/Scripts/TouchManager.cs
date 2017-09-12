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



    //=========================================================================

    void Update()
    {
        if(Input.GetMouseButton(0))
        {

        }
    }


}

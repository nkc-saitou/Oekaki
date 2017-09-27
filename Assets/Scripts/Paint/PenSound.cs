using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenSound : MonoBehaviour
{
    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    Vector3 beforePos;

    //=========================================================================
	void Update ()
    {
        //音を鳴らす
		if(SoundCheck())
        {
            beforePos = Input.mousePosition;
            SoundManager.instance.PlayBack_Pen();
        }
	}
    //-------------------------------------------------------------------------
    //  判断
    //-------------------------------------------------------------------------
    bool SoundCheck()
    {
        return Input.GetMouseButton(0) && Input.mousePosition != beforePos;
    }
}

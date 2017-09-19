using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Manager/TouchManager")]
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
            return;
        }
    }

    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------
    bool isTouch = true;

    [SerializeField]
    LayerMask layerMask;

    GameObject touchObj;

    //=========================================================================
    void Update()
    {
        if (!isTouch) return;

        if (Input.GetMouseButton(0))
        {
            Touch();
        }
    }
    //-------------------------------------------------------------------------
    //  タッチ処理
    //-------------------------------------------------------------------------
    void Touch()
    {
        //Ray
        Ray ray = Camera.main.ScreenPointToRay(TouchOrClickPos());
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100.0f, layerMask))
        {
            //RayHit呼び出し
            if(hit.collider.tag != "Obs") hit.collider.SendMessage("RayHit", hit.textureCoord * 256);
        }
    }

    Vector3 TouchOrClickPos()
    {
        return (Input.touchSupported) ? (Vector3)Input.touches[0].position : Input.mousePosition;
    }
    //-------------------------------------------------------------------------
    //  有効・無効
    //-------------------------------------------------------------------------
    public void IsTouch(bool flg)
    {
        isTouch = flg;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Handle : BaseGimmick {

    public GameObject Handle;
    Vector3 HandlePos;
    float speed = 1.5f;

    public override void GimmickActivate()
    {
        transform.Rotate(new Vector3(0, 0, 2));

        HandlePos = Handle.transform.position;
        HandlePos.y += speed * Time.deltaTime;
        Handle.transform.position = HandlePos;
    }

    public override void BorderSetting()
    {
        GimmickAct = 20;
    }
}
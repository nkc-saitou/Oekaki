using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Gimmick/Gimmick_Handle")]
public class Gimmick_Handle : BaseGimmick
{
    const float HANDLE_BORDER = 7.5f;

    public GameObject Handle;
    Vector3 HandlePos;
    float speed = 1.5f;

    void Start()
    {
        base.Start();
        gimmickAct = 20;
    }

    public override void OneActivate()
    {
        if (Handle.transform.position.y >= HANDLE_BORDER) return;

        transform.Rotate(new Vector3(0, 0, 2));

        HandlePos = Handle.transform.position;
        HandlePos.y += speed * Time.deltaTime;
        Handle.transform.position = HandlePos;
    }
}
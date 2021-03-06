﻿using System.Collections;
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

        //transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, 2));
        transform.Rotate(Vector3.forward * 45.0f * Time.deltaTime);

        HandlePos = Handle.transform.position;
        HandlePos.y += speed * Time.deltaTime;
        Handle.transform.position = HandlePos;
    }
}
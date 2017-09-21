﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            GameObject obj = other.gameObject;
            gameObject.transform.parent = obj.transform;
        }
    }
}
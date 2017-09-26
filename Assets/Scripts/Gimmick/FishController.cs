using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Gimmick/FishController")]
public class FishController : MonoBehaviour
{

    //衝突コールバック
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Esa"))
        {
            Destroy(col.gameObject);
        }
    }
}
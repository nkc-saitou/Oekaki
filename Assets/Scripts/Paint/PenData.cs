using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PenData : ScriptableObject
{
    //ペンの色
    public Color[] colorArr;
    //インク量
    public int[] colorNumArr;
}

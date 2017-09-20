using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Title/TitleCar")]
public class TitleCar : MonoBehaviour
{
    //クラクション
    public void CarHorn() { SoundManager.instance.PlayBack_SE(SoundManager.SE.Car); }
}

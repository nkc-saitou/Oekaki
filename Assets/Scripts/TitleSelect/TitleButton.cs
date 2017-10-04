using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/TitleSelect/Title/TitleButton")]
public class TitleButton : MonoBehaviour
{
    void OnMouseDown()
    {
        //シーン遷移
        SceneOption.Instance.TransitionScene("SelectScene");
    }
}

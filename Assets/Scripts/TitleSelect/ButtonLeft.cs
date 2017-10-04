using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonLeft : MonoBehaviour
{
    public void SceneLoad()
    {
        SceneManager.LoadScene("Title");
    }
}
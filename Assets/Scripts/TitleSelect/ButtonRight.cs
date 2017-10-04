using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonRight : MonoBehaviour
{
    public void SceneLoad()
    {
        SceneManager.LoadScene("GameScene_01");
    }
}
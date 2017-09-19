using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    //Scene遷移
    public void SceneLoad()
    {
        SceneManager.LoadScene("main");
    }
}
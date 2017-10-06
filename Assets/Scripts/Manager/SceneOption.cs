using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("Scripts/Manager/SceneOption")]
public class SceneOption : MonoBehaviour {

    #region Singleton

    private static SceneOption instance;

    public static SceneOption Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (SceneOption)FindObjectOfType(typeof(SceneOption));

                if (instance == null)
                {
                    Debug.LogError(typeof(SceneOption) + "is nothing");
                }
            }

            return instance;
        }
    }

    #endregion Singleton

    /// <summary>遷移用アニメーション</summary>
    public TransitionAnim transitionPre;

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// シーン読み込み .
    /// </summary>
    /// <param name='scene'>シーン名</param>
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// シーン遷移 .
    /// </summary>
    /// <param name='scene'>シーン名</param>
    public void TransitionScene(string scene,float waitTime = 0)
    {
        StartCoroutine(TransitionWaitTime(scene, waitTime));
    }

    IEnumerator TransitionWaitTime(string scene, float waitTime = 0)
    {
        yield return new WaitForSeconds(waitTime);

        //生成
        TransitionAnim transitionObj = Instantiate(transitionPre);
        transitionObj.SetNextSceneName(scene);

    }

    /// <summary>
    /// 現在のシーン名 .
    /// </summary>
    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
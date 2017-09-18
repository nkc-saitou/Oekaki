using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButton : MonoBehaviour {


    public enum SceneType
    {
        title = 0,
        stage1,
        stage2,
        stage3
    }
    public SceneType sceneType;


	void Start () {
		
	}
	

	void Update ()
    {
        if(Input.GetMouseButtonDown(0) && sceneType == SceneType.title)
        {
            SceneOption.Instance.LoadScene("SelectScene",1);
        }
	}

    public void OnButtonDown()
    {
        switch (sceneType)
        {
            case SceneType.stage1:
                SceneOption.Instance.LoadScene("Main", 1);
                break;

            case SceneType.stage2:
                SceneOption.Instance.LoadScene("Main", 1);
                break;

            case SceneType.stage3:
                SceneOption.Instance.LoadScene("Main", 1);
                break;
        }
    }
}

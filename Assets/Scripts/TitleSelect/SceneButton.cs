using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/TitleSelect/Select/SceneButton")]
public class SceneButton : MonoBehaviour {


    public enum SceneType
    {
        stage1,
        stage2,
        stage3
    }
    public SceneType sceneType;


	void Start () {
		
	}
	

	void Update ()
    {

	}

    public void OnButtonDown()
    {
        switch (sceneType)
        {
            case SceneType.stage1:
                SceneOption.Instance.LoadScene("GameScene_01");
                break;

            case SceneType.stage2:
                SceneOption.Instance.LoadScene("GameScene_02");
                break;

            case SceneType.stage3:
                SceneOption.Instance.LoadScene("GameScene_03");
                break;
        }

        //BGM切り替え
        SoundManager.instance.PlayBack_BGM(SoundManager.BGM.Game);
    }
}

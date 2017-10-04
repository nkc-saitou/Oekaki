using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class ImageChange : MonoBehaviour
{
    public Sprite stageSelectSp; //変えたい画像
    public GameObject stageSelectDisplay; //変えたい画像を設置するオブジェクト
   
    private SpriteRenderer stageSelectRenderer;
   
    //リスト
    private List<int> myList = new List<int>();

    int selectNo = 0;

    void Start()
    {
        //stageSelectDisplayのSpriteRendererの情報を持ってくる
        stageSelectRenderer = stageSelectDisplay.GetComponent<SpriteRenderer>();

        for (int i = 0; i < 10; i++)
        {
            myList.Add(i); 
        } 
    }

    void Update()
    {
        int[] table = new int[5];
        
    }

    //クリック処理
    public void DoClick()
    {
        selectNo = (int)Mathf.Repeat(selectNo + 1, myList.Count);

        //ボタンをおされたらspriteを変更
        stageSelectRenderer.sprite = stageSelectSp;
    }
}

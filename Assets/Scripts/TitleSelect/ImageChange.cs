using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Scripts/TitleSelect/Select/ImageChange")]
public class ImageChange : MonoBehaviour
{
    public SpriteRenderer stageSelectRenderer;

    public Sprite[] picture;
    //リスト
    private List<int> myList = new List<int>();

    int selectNo = 0;

    int pictureNum;

    void Start()
    {
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
    public void DoClick(int num)
    {
        pictureNum = (int)Mathf.Repeat(pictureNum + num, picture.Length);

        //ボタンをおされたらspriteを変更
        stageSelectRenderer.sprite = picture[pictureNum];
    }
}

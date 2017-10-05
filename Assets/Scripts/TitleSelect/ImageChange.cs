using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class ImageChange : MonoBehaviour
{
    public Image stageSelectImg;

    public Sprite[] picture;
    //リスト
    private List<int> myList = new List<int>();

    int selectNo = 0;

    int pictureNum;

    void Start()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    myList.Add(i);
        //}
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
        stageSelectImg.sprite = picture[pictureNum];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappaController : MonoBehaviour {

    //------------------------------------------
    // private
    //------------------------------------------

    Animator anim;

    bool gageHealFlg = true;

    //------------------------------------------
    // public
    //------------------------------------------

    public PixCheck pixCheck;
    public Animator[] happaAnim;
    public int[] happaTrigger;

    public GameObject flowerObj;

    public int gageHeal;

    public ColorGage colorGage;

    public PenData penDate;

    //=============================================================

	void Start ()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("grow");
        flowerObj.SetActive(false);

    }
	
	void Update ()
    {
        happaGrow();
    }

    //------------------------------------------
    // はっぱが成長するメソッド
    //------------------------------------------
    void happaGrow()
    {
        //一段目の芽
        if (pixCheck.PixelsPaint >= happaTrigger[0])
        {
            happaAnim[0].SetTrigger("grow");
        }
        //二段目の芽
        if (pixCheck.PixelsPaint >= happaTrigger[1] && gageHealFlg)
        {
            happaAnim[1].SetTrigger("grow");

            flowerObj.SetActive(true);

            int colorRandom = Random.Range(0, penDate.colorArr.Length);
            colorGage.GageHeal(penDate.colorArr[colorRandom], gageHeal);

            gageHealFlg = false;
        }
    }
}
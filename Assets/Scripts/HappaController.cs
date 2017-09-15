using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappaController : MonoBehaviour {

    Animator anim;

    public PixCheck pixCheck;
    public Animator[] happaAnim;
    public int[] happaTrigger;

    public ColorGage colorGage;

	void Start ()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("grow");
	}
	
	void Update ()
    {
        //if (pixCheck.PixelsPaint >= happaTrigger[0])
        //{
        //    happaAnim[0].SetTrigger("grow");
        //}

        //if(pixCheck.PixelsPaint >= happaTrigger[1])
        //{
        //    happaAnim[1].SetTrigger("grow");
        //}

        StartCoroutine(happaGrow());
	}

    IEnumerator happaGrow()
    {
        if (pixCheck.PixelsPaint >= happaTrigger[0])
        {
            happaAnim[0].SetTrigger("grow");
        }

        if (pixCheck.PixelsPaint >= happaTrigger[1])
        {
            happaAnim[1].SetTrigger("grow");

            yield return new WaitForSeconds(0.5f);

            colorGage.GageHeal(Color.red,10);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixCheck : MonoBehaviour {

    Texture2D mainTexture;
    Color[] pixels;

    void Start ()
    {

    }

    void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
            pixels = mainTexture.GetPixels();

            int count = 0;

            foreach(Color c in pixels)
            {
                if (c == Color.white)
                    count++;
            }

            Debug.Log(count);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixAcces : MonoBehaviour
{
    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    //[SerializeField]
    Renderer renderer;
    
    public static Color penColor;
    public static bool isPenUse;

    Texture2D drawTexture;
    Color[] buffer;

    //=========================================================================

    void Start()
    {
        renderer = GetComponent<Renderer>();

        Texture2D mainTexture = (Texture2D)renderer.material.mainTexture;
        Color[] pixels = mainTexture.GetPixels();

        buffer = new Color[pixels.Length];
        pixels.CopyTo(buffer, 0);

        drawTexture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        drawTexture.filterMode = FilterMode.Point;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && isPenUse)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (gameObject.GetInstanceID() == hit.collider.gameObject.GetInstanceID())
                    Draw(hit.textureCoord * 256);
            }

            drawTexture.SetPixels(buffer);
            drawTexture.Apply();
            renderer.material.mainTexture = drawTexture;
        }
    }

    //-------------------------------------------------------------------------
    //  Draw
    //-------------------------------------------------------------------------

    public void Draw(Vector2 p)
    {
        for (int x = 0; x < 256; x++)
        {
            for (int y = 0; y < 256; y++)
            {
                if ((p - new Vector2(x, y)).magnitude < 5)
                {
                    Color cccc = penColor;
                    cccc.a = buffer[x + 256 * y].a;
                    buffer.SetValue(cccc, x + 256 * y);
                }
            }
        }
    }
}
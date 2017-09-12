using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PixCheck))]
[AddComponentMenu("Scripts/Paint/PixAcces")]
public class PixAcces : MonoBehaviour
{
    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    new Renderer renderer;
    
    public static Color penColor;
    public static bool isPenUse;

    Texture2D drawTexture;
    Color[] buffer;

    bool touching;
    Vector2 beforePoint;

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
                {
                    Vector2 point = hit.textureCoord * 256;

                    if (touching)
                        DrawLine(point, beforePoint);
                    else
                        Draw(point);

                    beforePoint = point;
                    touching = true;
                }
                else
                {
                    touching = false;
                }
            }

            drawTexture.SetPixels(buffer);
            drawTexture.Apply();
            renderer.material.mainTexture = drawTexture;
        }
        else
        {
            touching = false;
        }
    }

    //-------------------------------------------------------------------------
    //  塗るメソッド
    //-------------------------------------------------------------------------
    public void Draw(Vector2 p)
    {
        for (int x = 0; x < 256; x++)
        {
            for (int y = 0; y < 256; y++)
            {
                if ((p - new Vector2(x, y)).magnitude < 5)
                {
                    Color cccc = (buffer[x + 256 * y] == Color.black) ? Color.black : penColor;
                    cccc.a = buffer[x + 256 * y].a;
                    buffer.SetValue(cccc, x + 256 * y);
                }
            }
        }
    }

    public void DrawLine(Vector2 p, Vector2 q)
    {
        int lerpNum = 10;
        for (int i = 0; i < lerpNum + 1; i++)
        {
            Vector2 r = Vector2.Lerp(p, q, i * (1.0f / lerpNum));
            Draw(r);
        }
    }

    //-------------------------------------------------------------------------
    //  回収するメソッド
    //-------------------------------------------------------------------------
    void Collection()
    {

    }
}
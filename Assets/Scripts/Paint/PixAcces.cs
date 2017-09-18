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

    public static Color penColor;   //ペンの色
    public static bool isPenUse;    //ペンフラグ
    public static int gageCount = 0;  //ゲージ減少カウント

    Texture2D drawTexture;
    Color[] buffer;

    Vector2 beforePoint;

    ColorGage colorGage;

    //=========================================================================

    void Start()
    {
        renderer = GetComponent<Renderer>();
        //ColorGage取得
        colorGage = GameObject.Find("ColorCanvas").GetComponent<ColorGage>();

        Texture2D mainTexture = (Texture2D)renderer.material.mainTexture;
        Color[] pixels = mainTexture.GetPixels();

        buffer = new Color[pixels.Length];
        pixels.CopyTo(buffer, 0);

        drawTexture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        drawTexture.filterMode = FilterMode.Point;
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
                    int pixNo = x + 256 * y;
                    Color cccc = (buffer[pixNo] == Color.black) ? Color.black : penColor;
                    cccc.a = buffer[pixNo].a;
                    //カウント
                    if (IsCount(cccc, buffer[pixNo])) gageCount++;
                    //色をセット
                    buffer.SetValue(cccc, pixNo);
                    //カウント確認
                    if (gageCount >= 512)
                    {
                        colorGage.GageDown();
                        gageCount = 0;
                    }
                }
            }
        }
    }

    //-------------------------------------------------------------------------
    //  カウントをチェック
    //-------------------------------------------------------------------------
    bool IsCount(Color cC, Color bC)
    {
        return cC != bC && bC != Color.black;
    }

    //-------------------------------------------------------------------------
    //  RayHit
    //-------------------------------------------------------------------------
    void RayHit(Vector2 point)
    {
        if(beforePoint != point)
        {
            //描く
            Draw(point);
            //位置を記憶
            beforePoint = point;

            SoundManager.instance.PlayBack_Pen();
        }

        //反映
        drawTexture.SetPixels(buffer);
        drawTexture.Apply();
        renderer.material.mainTexture = drawTexture;
    }

    //-------------------------------------------------------------------------
    //  ゲージ回復確認用メソッド
    //-------------------------------------------------------------------------
    [ContextMenu("Heal")]
    void Heal()
    {
        colorGage.GageHeal(Color.red, 20);
    }
}
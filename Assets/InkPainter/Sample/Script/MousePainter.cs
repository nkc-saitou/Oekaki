using UnityEngine;

namespace Es.InkPainter.Sample
{
    public enum PaintColor
    {
        Red = 0,
        Green,
        Blue,
        Empty
    }

	public class MousePainter : MonoBehaviour
	{
		/// <summary>
		/// Types of methods used to paint.
		/// </summary>
		[System.Serializable]
		private enum UseMethodType
		{
			RaycastHitInfo,
			WorldPoint,
			NearestSurfacePoint,
			DirectUV,
		}

		[SerializeField]
		private Brush brush;

		[SerializeField]
		private UseMethodType useMethodType = UseMethodType.RaycastHitInfo;

        //ColorGage
        [SerializeField]
        ColorGage colorGage;

        //前回の位置
        Vector3 beforePos;

        //使える色
        Color[] useColor = { Color.red, Color.green, Color.blue };

        //ペン情報
        public static bool isBrushUse = true;
        public static PaintColor brushColor = PaintColor.Red;
        public static float brushScale = 0.1f;

        private void Update()
		{
            if (useColor[(int)brushColor] != brush.Color) brush.Color = useColor[(int)brushColor];
            if (brushScale != brush.Scale) brush.Scale = brushScale;

			if(isBrushUse && Input.GetMouseButton(0))
			{
				var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				bool success = true;
				RaycastHit hitInfo;
				if(Physics.Raycast(ray, out hitInfo))
				{
					var paintObject = hitInfo.transform.GetComponent<InkCanvas>();
					if(paintObject != null)
                    {
                        switch (useMethodType)
                        {
                            case UseMethodType.RaycastHitInfo:
                                success = paintObject.Paint(brush, hitInfo);
                                break;

                            case UseMethodType.WorldPoint:
                                success = paintObject.Paint(brush, hitInfo.point);
                                break;

                            case UseMethodType.NearestSurfacePoint:
                                success = paintObject.PaintNearestTriangleSurface(brush, hitInfo.point);
                                break;

                            case UseMethodType.DirectUV:
                                if (!(hitInfo.collider is MeshCollider))
                                    Debug.LogWarning("Raycast may be unexpected if you do not use MeshCollider.");
                                success = paintObject.PaintUVDirect(brush, hitInfo.textureCoord);
                                break;
                        }

                        //前回位置と違うならtrue
                        if (PositionCheck())
                        {
                            beforePos = Input.mousePosition;
                            //ゲージ減少
                            colorGage.GageDown((int)brushColor, brushScale * 10);
                            //効果音
                            SoundManager.instance.PlayBack_Pen();
                        }
                    }
						
					if(!success)
						Debug.LogError("Failed to paint.");
				}
			}
		}

        //public void OnGUI()
        //{
        //	if(GUILayout.Button("Reset"))
        //	{
        //		foreach(var canvas in FindObjectsOfType<InkCanvas>())
        //			canvas.ResetPaint();
        //	}
        //}

        //-------------------------------------------------------------------------
        //  判断
        //-------------------------------------------------------------------------
        bool PositionCheck()
        {
            return Input.mousePosition != beforePos;
        }
    }
}
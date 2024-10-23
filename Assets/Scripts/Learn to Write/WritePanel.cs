

using UnityEngine;
using System.Collections.Generic;

public class WritePanel : MonoBehaviour
{
#if UNITY_EDITOR
	[ContextMenu("Get Beziers")]
	void GetBeziers ()
	{
		if (!UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode) {
			for (int i=writeManager.parentForLines.childCount-1; i>=0; i--) {
				DestroyImmediate (writeManager.parentForLines.GetChild (i).gameObject);
			}
			InitLines ();
			for (int i=0; i<lines.Count; i++) {
				lines [i].lineRef.gameObject.SetActive (true);
			}
		}
	}
#endif

	public WriteManager writeManager;
	public List<WriteLine> lines = new List<WriteLine> ();

	public void InitLines ()
	{
		lines.Clear ();
		BezierSpline[] writeBezierSplines = GetComponentsInChildren<BezierSpline> (true);
		WriteLine wlT = null;
		for (int wi=0; wi<writeBezierSplines.Length; wi++) {
			if (writeBezierSplines [wi].frequency > 0) {
				float stepSize = writeBezierSplines [wi].frequency;
				if (writeBezierSplines [wi].Loop || System.Math.Abs (stepSize - 1) < Mathf.Epsilon) {
					stepSize = 1f / stepSize;
				} else {
					stepSize = 1f / (stepSize - 1);
				}
				for (int f = 0; f < writeBezierSplines [wi].frequency; f++) {
					WriteLine wl = Instantiate<WriteLine> (writeManager.writeLine);
					wl.transform.SetParent (writeManager.parentForLines);
					wl.transform.localScale = Vector3.one;
					wl.rectTransform.position = writeBezierSplines [wi].GetPoint (f * stepSize);
					Vector3 len = writeBezierSplines [wi].GetPoint ((f + 1) * stepSize) - wl.rectTransform.position;
					wl.rectTransform.sizeDelta = new Vector2 (len.magnitude / wl.transform.lossyScale.x, 0);
					float a = Mathf.Atan2 (-len.x, len.y) * Mathf.Rad2Deg + 90;
					wl.rectTransform.localEulerAngles = new Vector3 (0, 0, a);
					wl.lineRef.gameObject.SetActive (false);
					if (f == 0) {
						wl.isSparate = true;
					}
					if (wlT) {
						wlT.nextArea = wl.gameObject;
					}
					wlT = wl;
					lines.Add (wl);
				}
				
			}
		}
	}
	
}

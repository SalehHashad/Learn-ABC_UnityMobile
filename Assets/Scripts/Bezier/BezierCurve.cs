

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class BezierCurve : MonoBehaviour
{
	
	public Vector3[] points;
	
	public Vector3 GetPoint (float t)
	{
		return transform.TransformPoint (Bezier.GetPoint (points [0], points [1], points [2], points [3], t));
	}
	
	public Vector3 GetVelocity (float t)
	{
		return transform.TransformPoint (Bezier.GetFirstDerivative (points [0], points [1], points [2], points [3], t)) - transform.position;
	}
	
	public Vector3 GetDirection (float t)
	{
		return GetVelocity (t).normalized;
	}
	
	public void Reset ()
	{
		points = new Vector3[] {
			new Vector3 (1f, 0f, 0f),
			new Vector3 (2f, 0f, 0f),
			new Vector3 (3f, 0f, 0f),
			new Vector3 (4f, 0f, 0f)
		};
	}
}

#if UNITY_EDITOR
[CustomEditor(typeof(BezierCurve))]
public class BezierCurveInspector : Editor
{
	
	const int lineSteps = 10;
	const float directionScale = 0.5f;
	
	BezierCurve curve;
	Transform handleTransform;
	Quaternion handleRotation;
	
	void OnSceneGUI ()
	{
		curve = target as BezierCurve;
		handleTransform = curve.transform;
		handleRotation = Tools.pivotRotation == PivotRotation.Local ?
			handleTransform.rotation : Quaternion.identity;
		
		Vector3 p0 = ShowPoint (0);
		Vector3 p1 = ShowPoint (1);
		Vector3 p2 = ShowPoint (2);
		Vector3 p3 = ShowPoint (3);
		
		Handles.color = Color.gray;
		Handles.DrawLine (p0, p1);
		Handles.DrawLine (p2, p3);
		
		ShowDirections ();
		Handles.DrawBezier (p0, p3, p1, p2, Color.white, null, 2f);
	}
	
	void ShowDirections ()
	{
		Handles.color = Color.green;
		Vector3 point = curve.GetPoint (0f);
		Handles.DrawLine (point, point + curve.GetDirection (0f) * directionScale);
		for (int i = 1; i <= lineSteps; i++) {
			point = curve.GetPoint (i / (float)lineSteps);
			Handles.DrawLine (point, point + curve.GetDirection (i / (float)lineSteps) * directionScale);
		}
	}
	
	Vector3 ShowPoint (int index)
	{
		Vector3 point = handleTransform.TransformPoint (curve.points [index]);
		EditorGUI.BeginChangeCheck ();
		point = Handles.DoPositionHandle (point, handleRotation);
		if (EditorGUI.EndChangeCheck ()) {
			Undo.RecordObject (curve, "Move Point");
			EditorUtility.SetDirty (curve);
			curve.points [index] = handleTransform.InverseTransformPoint (point);
		}
		return point;
	}
}
#endif

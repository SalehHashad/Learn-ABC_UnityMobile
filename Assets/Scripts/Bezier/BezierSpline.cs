

using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public enum BezierControlPointMode
{
	Free,
	Aligned,
	Mirrored
}

public class BezierSpline : MonoBehaviour
{

	[SerializeField]
	Vector3[]
		points;
	
	[SerializeField]
	BezierControlPointMode[]
		modes;
	
	[SerializeField]
	bool
		loop;

	public int
		frequency;
	
	public bool Loop {
		get {
			return loop;
		}
		set {
			loop = value;
			if (value) {
				modes [modes.Length - 1] = modes [0];
				SetControlPoint (0, points [0]);
			}
		}
	}

	public int ControlPointCount {
		get {
			return points.Length;
		}
	}
	
	public Vector3 GetControlPoint (int index)
	{
		return points [index];
	}
	
	public void SetControlPoint (int index, Vector3 point)
	{
		if (index % 3 == 0) {
			Vector3 delta = point - points [index];
			if (loop) {
				if (index == 0) {
					points [1] += delta;
					points [points.Length - 2] += delta;
					points [points.Length - 1] = point;
				} else if (index == points.Length - 1) {
					points [0] = point;
					points [1] += delta;
					points [index - 1] += delta;
				} else {
					points [index - 1] += delta;
					points [index + 1] += delta;
				}
			} else {
				if (index > 0) {
					points [index - 1] += delta;
				}
				if (index + 1 < points.Length) {
					points [index + 1] += delta;
				}
			}
		}
		points [index] = point;
		EnforceMode (index);
	}
	
	public BezierControlPointMode GetControlPointMode (int index)
	{
		return modes [(index + 1) / 3];
	}
	
	public void SetControlPointMode (int index, BezierControlPointMode mode)
	{
		int modeIndex = (index + 1) / 3;
		modes [modeIndex] = mode;
		if (loop) {
			if (modeIndex == 0) {
				modes [modes.Length - 1] = mode;
			} else if (modeIndex == modes.Length - 1) {
				modes [0] = mode;
			}
		}
		EnforceMode (index);
	}
	
	void EnforceMode (int index)
	{
		int modeIndex = (index + 1) / 3;
		BezierControlPointMode mode = modes [modeIndex];
		if (mode == BezierControlPointMode.Free || !loop && (modeIndex == 0 || modeIndex == modes.Length - 1)) {
			return;
		}
		
		int middleIndex = modeIndex * 3;
		int fixedIndex, enforcedIndex;
		if (index <= middleIndex) {
			fixedIndex = middleIndex - 1;
			if (fixedIndex < 0) {
				fixedIndex = points.Length - 2;
			}
			enforcedIndex = middleIndex + 1;
			if (enforcedIndex >= points.Length) {
				enforcedIndex = 1;
			}
		} else {
			fixedIndex = middleIndex + 1;
			if (fixedIndex >= points.Length) {
				fixedIndex = 1;
			}
			enforcedIndex = middleIndex - 1;
			if (enforcedIndex < 0) {
				enforcedIndex = points.Length - 2;
			}
		}
		
		Vector3 middle = points [middleIndex];
		Vector3 enforcedTangent = middle - points [fixedIndex];
		if (mode == BezierControlPointMode.Aligned) {
			enforcedTangent = enforcedTangent.normalized * Vector3.Distance (middle, points [enforcedIndex]);
		}
		points [enforcedIndex] = middle + enforcedTangent;
	}
	
	public int CurveCount {
		get {
			return (points.Length - 1) / 3;
		}
	}
	
	public Vector3 GetPoint (float t)
	{
		int i;
		if (t >= 1f) {
			t = 1f;
			i = points.Length - 4;
		} else {
			t = Mathf.Clamp01 (t) * CurveCount;
			i = (int)t;
			t -= i;
			i *= 3;
		}
		return transform.TransformPoint (Bezier.GetPoint (points [i], points [i + 1], points [i + 2], points [i + 3], t));
	}
	
	public Vector3 GetVelocity (float t)
	{
		int i;
		if (t >= 1f) {
			t = 1f;
			i = points.Length - 4;
		} else {
			t = Mathf.Clamp01 (t) * CurveCount;
			i = (int)t;
			t -= i;
			i *= 3;
		}
		return transform.TransformPoint (Bezier.GetFirstDerivative (points [i], points [i + 1], points [i + 2], points [i + 3], t)) - transform.position;
	}
	
	public Vector3 GetDirection (float t)
	{
		return GetVelocity (t).normalized;
	}
	
	public void AddCurve ()
	{
		Vector3 point = points [points.Length - 1];
		Array.Resize (ref points, points.Length + 3);
		point.x += 100f;
		points [points.Length - 3] = point;
		point.x += 100f;
		points [points.Length - 2] = point;
		point.x += 100f;
		points [points.Length - 1] = point;
		
		Array.Resize (ref modes, modes.Length + 1);
		modes [modes.Length - 1] = modes [modes.Length - 2];
		EnforceMode (points.Length - 4);
		
		if (loop) {
			points [points.Length - 1] = points [0];
			modes [modes.Length - 1] = modes [0];
			EnforceMode (0);
		}
	}

	public void ReduceCurve ()
	{
		Array.Resize (ref points, points.Length - 3);
		Array.Resize (ref modes, modes.Length - 1);
		modes [modes.Length - 1] = modes [modes.Length - 2];
		EnforceMode (points.Length - 4);
		
		if (loop) {
			points [points.Length - 1] = points [0];
			modes [modes.Length - 1] = modes [0];
			EnforceMode (0);
		}
	}
	
	public void Reset ()
	{
		points = new Vector3[] {
			new Vector3 (100f, 0f, 0f),
			new Vector3 (200f, 0f, 0f),
			new Vector3 (300f, 0f, 0f),
			new Vector3 (400f, 0f, 0f)
		};
		modes = new BezierControlPointMode[] {
			BezierControlPointMode.Free,
			BezierControlPointMode.Free
		};
	}
}

#if UNITY_EDITOR
[CustomEditor(typeof(BezierSpline))]
public class BezierSplineInspector : Editor
{
	
	const int stepsPerCurve = 10;
	const float directionScale = 0.5f;
	const float handleSize = 0.04f;
	const float pickSize = 0.06f;
	
	static Color[] modeColors = {
		Color.blue,
		Color.yellow,
		Color.cyan
	};
	
	BezierSpline spline;
	Transform handleTransform;
	Quaternion handleRotation;
	int selectedIndex = -1;
	
	public override void OnInspectorGUI ()
	{
		spline = target as BezierSpline;
		EditorGUI.BeginChangeCheck ();
		bool loop = EditorGUILayout.Toggle ("Loop", spline.Loop);
		if (EditorGUI.EndChangeCheck ()) {
			Undo.RecordObject (spline, "Toggle Loop");
			EditorUtility.SetDirty (spline);
			spline.Loop = loop;
		}
		EditorGUI.BeginChangeCheck ();
		int freq = EditorGUILayout.IntField ("Frequency", spline.frequency);//.Toggle ("Loop", spline.Loop);
		if (EditorGUI.EndChangeCheck ()) {
			Undo.RecordObject (spline, "Spline Frequency");
			EditorUtility.SetDirty (spline);
			spline.frequency = freq;
		}
		if (selectedIndex >= 0 && selectedIndex < spline.ControlPointCount) {
			DrawSelectedPointInspector ();
		}
		if (GUILayout.Button ("Add Curve")) {
			Undo.RecordObject (spline, "Add Curve");
			spline.AddCurve ();
			EditorUtility.SetDirty (spline);
		}
		if (GUILayout.Button ("Reduce Curve")) {
			Undo.RecordObject (spline, "Reduce Curve");
			spline.ReduceCurve ();
			EditorUtility.SetDirty (spline);
		}
	}
	
	void DrawSelectedPointInspector ()
	{
		GUILayout.Label ("Selected Point");
		EditorGUI.BeginChangeCheck ();
		Vector3 point = EditorGUILayout.Vector3Field ("Position", spline.GetControlPoint (selectedIndex));
		if (EditorGUI.EndChangeCheck ()) {
			Undo.RecordObject (spline, "Move Point");
			EditorUtility.SetDirty (spline);
			spline.SetControlPoint (selectedIndex, point);
		}
		EditorGUI.BeginChangeCheck ();
		BezierControlPointMode mode = (BezierControlPointMode)EditorGUILayout.EnumPopup ("Mode", spline.GetControlPointMode (selectedIndex));
		if (EditorGUI.EndChangeCheck ()) {
			Undo.RecordObject (spline, "Change Point Mode");
			spline.SetControlPointMode (selectedIndex, mode);
			EditorUtility.SetDirty (spline);
		}
	}
	
	void OnSceneGUI ()
	{
		spline = target as BezierSpline;
		handleTransform = spline.transform;
		handleRotation = Tools.pivotRotation == PivotRotation.Local ?
			handleTransform.rotation : Quaternion.identity;
		
		Vector3 p0 = ShowPoint (0);
		for (int i = 1; i < spline.ControlPointCount; i += 3) {
			Vector3 p1 = ShowPoint (i);
			Vector3 p2 = ShowPoint (i + 1);
			Vector3 p3 = ShowPoint (i + 2);
			
			Handles.color = Color.gray;
			Handles.DrawLine (p0, p1);
			Handles.DrawLine (p2, p3);
			
			Handles.DrawBezier (p0, p3, p1, p2, Color.yellow, null, 2f);
			p0 = p3;
		}
		ShowDirections ();
	}
	
	void ShowDirections ()
	{
		Handles.color = Color.green;
		Vector3 point = spline.GetPoint (0f);
		Handles.DrawLine (point, point + spline.GetDirection (0f) * directionScale);
		int steps = stepsPerCurve * spline.CurveCount;
		for (int i = 1; i <= steps; i++) {
			point = spline.GetPoint (i / (float)steps);
			Handles.DrawLine (point, point + spline.GetDirection (i / (float)steps) * directionScale);
		}
	}
	
	Vector3 ShowPoint (int index)
	{
		Vector3 point = handleTransform.TransformPoint (spline.GetControlPoint (index));
		float size = HandleUtility.GetHandleSize (point) * 1.5f;
		if (index == 0) {
			size *= 2f;
		} else if (index % 3 == 0) {
			size *= 1.5f;
		}
		Handles.color = modeColors [(int)spline.GetControlPointMode (index)];
		
		                                                  // replace Handles.DotCap with Handles.DotHandleCap 
		if (Handles.Button (point, handleRotation, size * handleSize, size * pickSize, Handles.DotHandleCap)) {
			selectedIndex = index;
			Repaint ();
		}
		if (selectedIndex == index) {
			EditorGUI.BeginChangeCheck ();
			point = Handles.DoPositionHandle (point, handleRotation);
			if (EditorGUI.EndChangeCheck ()) {
				Undo.RecordObject (spline, "Move Point");
				EditorUtility.SetDirty (spline);
				spline.SetControlPoint (index, handleTransform.InverseTransformPoint (point));
			}
		}
		return point;
	}
}
#endif

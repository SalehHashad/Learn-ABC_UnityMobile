

using UnityEngine;
using UnityEngine.UI;

public class WriteLine : MonoBehaviour
{
	RectTransform m_rt;
	public RectTransform rectTransform {
		get {
			if (!m_rt) {
				m_rt = GetComponent<RectTransform> ();
			}
			return m_rt;
		}
	}
	public GameObject nextArea;
	public bool isSparate;
	public Image lineRef;
}

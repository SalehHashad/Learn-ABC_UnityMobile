

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class WriteDrawer : MonoBehaviour
	//,IBeginDragHandler
	,IDragHandler
	//,IDropHandler
	,IEndDragHandler
{
	public WriteManager writeManager;
	int currentIndex;
	bool isOver;

	#region IPointerHandler implementation
	
//	public void OnBeginDrag (PointerEventData eventData)
//	{
//		GameObject go = eventData.pointerCurrentRaycast.gameObject;
//		Debug.Log ("Begin " + go.name);
//	}
	
	public void OnDrag (PointerEventData eventData)
	{
		if (!isOver) {
			GameObject go = eventData.pointerCurrentRaycast.gameObject;
//		Debug.Log ("Drag " + go.name);
			if (go == gameObject) {
				writeManager.writePanels [GameParent.alphabetIndex].lines [currentIndex].lineRef.gameObject.SetActive (true);
				currentIndex++;
				if (writeManager.writePanels [GameParent.alphabetIndex].lines.Count > currentIndex) {
					transform.position = writeManager.writePanels [GameParent.alphabetIndex].lines [currentIndex].transform.position;
				} else {
					writeManager.congratsUI.OnActivatingUI (true);
					writeManager.PlayCompliSound ();
					isOver = true;
					//writeManager.OnNextButtonClick ();
				}
			}
		}
	}
	
//	public void OnDrop (PointerEventData eventData)
//	{
//		GameObject go = eventData.pointerCurrentRaycast.gameObject;
//		Debug.Log ("Drop " + go.name);
//	}
	
	public void OnEndDrag (PointerEventData eventData)
	{
		if (!isOver) {
//		GameObject go = eventData.pointerCurrentRaycast.gameObject;
//		Debug.Log ("End " + go.name);
			if (!writeManager.writePanels [GameParent.alphabetIndex].lines [currentIndex].isSparate) {
				writeManager.PlayMockSound ();
			}
		}
	}
	#endregion

	public void InitDrawer ()
	{
		isOver = false;
		currentIndex = 0;
		transform.position = writeManager.writePanels [GameParent.alphabetIndex].lines [0].transform.position;
	}

}

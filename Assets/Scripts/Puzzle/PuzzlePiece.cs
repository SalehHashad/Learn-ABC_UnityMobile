

using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IDragHandler,IBeginDragHandler,IDropHandler,IEndDragHandler
{

	public bool isInteractable = true;
	public Vector3 posisiAwal;
	public PuzzlePanel puzzlePanel;
	public bool isInPlace {
		get {
			return Vector3.Distance (transform.localPosition, posisiAwal) < 1;
		}
	}
	Vector2 pivot;

	#region IHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		pivot = transform.position;
		pivot = pivot - eventData.position;
		transform.SetAsLastSibling ();
	}
	
	public void OnDrag (PointerEventData eventData)
	{
		if (isInteractable) {
			transform.position = eventData.position + pivot;
			if (Vector3.Distance (transform.localPosition, posisiAwal) < puzzlePanel.puzzleManager.snapDistance) {
				transform.localPosition = posisiAwal;
			}
		}
	}
	
	public void OnDrop (PointerEventData eventData)
	{
		if (isInteractable) {
			transform.position = eventData.position + pivot;
			if (Vector3.Distance (transform.localPosition, posisiAwal) < puzzlePanel.puzzleManager.snapDistance) {
				transform.localPosition = posisiAwal;
			} else {
				puzzlePanel.puzzleManager.PlayMockSound ();
			}
		}
	}
	
	public void OnEndDrag (PointerEventData eventData)
	{
		if (isInteractable) {
			puzzlePanel.CheckPieces ();
		}
	}
	
	#endregion
	
}



using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PuzzlePanel : MonoBehaviour
{
#if UNITY_EDITOR
	[ContextMenu("Ambil Posisi")]
	void AmbilPosisi ()
	{
		if (posisiPieces != null && posisiPieces.Length > 0) {
			Array.Resize<PuzzlePiece> (ref posisiPieces, transform.childCount);
		} else {
			posisiPieces = new PuzzlePiece[transform.childCount];
		}
		for (int i=0; i<transform.childCount; i++) {
			Transform ttt = transform.GetChild (i);
			PuzzlePiece ppp;
			if (!(ppp = ttt.gameObject.GetComponent<PuzzlePiece> ())) {
				ppp = ttt.gameObject.AddComponent<PuzzlePiece> ();
			}
			ppp.posisiAwal = ppp.transform.localPosition;
			ppp.puzzlePanel = this;
			posisiPieces [i] = ppp;
		}
	}
#endif

	public PuzzleManager puzzleManager;
	public PuzzlePiece[] posisiPieces;

	void OnEnable ()
	{
		for (int i=0; i<posisiPieces.Length; i++) {
			posisiPieces [i].transform.localPosition = new Vector3 (UnityEngine.Random.Range (-300, 0), UnityEngine.Random.Range (-100, 101), 0);
			posisiPieces [i].isInteractable = true;
		}
	}

	public void CheckPieces ()
	{
		bool isComplete = true;
		for (int i=0; i<posisiPieces.Length; i++) {
			isComplete = posisiPieces [i].isInPlace && isComplete;
		}
		if (isComplete) {
			for (int i=0; i<posisiPieces.Length; i++) {
				posisiPieces [i].isInteractable = false;
			}
			puzzleManager.congratsUI.OnActivatingUI (true);
			puzzleManager.PlayCompliSound ();
		}
	}

}

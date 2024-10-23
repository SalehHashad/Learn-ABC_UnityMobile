

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WriteManager : GameParent
{
	public CongratzUIButtonGroup congratsUI;
	public WriteLine writeLine;
	public Transform parentForLines;
	public WriteDrawer PointButton;
	public WritePanel[] writePanels;
	public AudioClip beginSound;
	public AudioClip cringSound;
	public AudioClip[] compliSound;
	public AudioClip mockSound;

	protected override void InitAlphabets ()
	{
		for (int i = parentForLines.childCount - 1; i >= 0; i--) {
			Destroy (parentForLines.GetChild (i).gameObject);
		}
		//alphabetIndex = 0;
		for (int i = 0; i < writePanels.Length; i++) {
			writePanels [i].gameObject.SetActive (false);
		}
		writePanels [alphabetIndex].gameObject.SetActive (true);
		writePanels [alphabetIndex].InitLines ();
		PointButton.InitDrawer ();
	}

	public override void OnNextButtonClick ()
	{
		base.OnNextButtonClick ();
		congratsUI.OnActivatingUI (false);
	}

	public override void OnPrevButtonClick ()
	{
		base.OnPrevButtonClick ();
		congratsUI.OnActivatingUI (false);
	}

	public void PlayCompliSound ()
	{
		//Invoke ("PlayPrivCompli", 1);
		PlaySound (compliSound [UnityEngine.Random.Range (0, compliSound.Length)], 1);
		PlaySound (cringSound);
	}

	void PlayPrivCompli ()
	{
		PlaySound (compliSound [UnityEngine.Random.Range (0, compliSound.Length)], 1);
	}

	public void PlayMockSound ()
	{
		PlaySound (mockSound);
	}

	void PlaySound (AudioClip ac, float delay = 0)
	{
		if (ac) {
			StartCoroutine (PlaySoundRoutine (ac, delay));
		}
	}

	IEnumerator PlaySoundRoutine (AudioClip ac, float delay)
	{
		yield return new WaitForSeconds (delay);
		AudioSource.PlayClipAtPoint (ac, Vector3.zero);
	}

	void OnEnable ()
	{
		PlaySound (beginSound);
		InitAlphabets ();
	}
}



using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>

/// </summary>

public class MiniGameMaster : MonoBehaviour
{
	public static int id;
	public List<Transform> miniGamePanel = new List<Transform> ();

	void Start ()
	{
		foreach (Transform t in miniGamePanel)
			if (t != null)
				t.gameObject.SetActive (false);

		miniGamePanel [id].gameObject.SetActive (true);
	}
}

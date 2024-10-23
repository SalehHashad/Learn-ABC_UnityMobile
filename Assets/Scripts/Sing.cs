

using System;
using UnityEngine;

public static class Sing
{
	static GameManager _gm;
	public static GameManager gm {
		get {
			return _gm;
		}
	}
	
	[RuntimeInitializeOnLoadMethod]
	static void Bind ()
	{
	}
	
	static Sing ()
	{
		GameManager[] managers = UnityEngine.Object.FindObjectsOfType <GameManager> ();
		if (managers.Length != 0) {
			for (int i = 1; i < managers.Length; i++) {
				UnityEngine.Object.Destroy (managers [i].gameObject);
			}
			_gm = managers [0];
		} else {
			GameManager gem = Resources.Load <GameManager> ("GameManager");
			if (gem) {
				_gm = UnityEngine.Object.Instantiate <GameManager> (gem);
			}
			if (!_gm) {
				GameObject gO = new GameObject (typeof(GameManager).Name);
				_gm = gO.AddComponent <GameManager> ();
			}
		}
		_gm.gameObject.name = typeof(GameManager).Name;
		UnityEngine.Object.DontDestroyOnLoad (_gm.gameObject);
	}
	
}


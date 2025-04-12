

using UnityEngine;
using System.Collections;
using Photon.Pun;

public class SplashScreenBehaviour : MonoBehaviour
{
	public AudioClip splashSound;
	public string goToScene;
	public AnimationCurve soundCurve;

	AudioSource source;

	void Start ()
	{
		source = GetComponent<AudioSource> ();
		source.clip = splashSound;
		source.Play ();
		Sing.gm.ResetTime ();
		//Invoke ("loadLevel", splashSound.length);
		Debug.Log ("Tulaib");
	}

	void Update ()
	{
		if (Input.GetMouseButtonUp (0)) {
			CancelInvoke ();
			//loadLevel();
		}
		source.volume = soundCurve.Evaluate (source.time / splashSound.length);
	}

	private void loadLevel ()
	{
		PhotonNetwork.LoadLevel(goToScene);
		//Application.LoadLevel(goToScene);
	}
    public void loadLevel2()
    {
		PhotonNetwork.LoadLevel(goToScene);
		//Application.LoadLevel(goToScene);
	}
}

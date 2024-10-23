

using UnityEngine;
using System.Collections;

/// <summary>
/// Class parent untuk Script utama pada hampir semua minigame
/// </summary>

public class GameParent : MonoBehaviour
{
	public string backtoScene;

    public int fromIndex = 0;
    public int toIndex = 27;


    [HideInInspector]
	public static string
		alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    [HideInInspector]
    public static string
        arabicAlphabet = "أبتثجحخدذرزسشصضطظعغفقكلمنهوي";
    public static int alphabetIndex = 0;

    /// Jika user menekan tombol back, game akan 
    /// kembali pada menu sebelumnya

    private void Awake()
    {
        if(GameManager.Instance != null)
        {

            alphabetIndex = GameManager.Instance.fromIndex;
            fromIndex = GameManager.Instance.fromIndex;
            toIndex = GameManager.Instance.toIndex;
        }
        else
        {
            print("Nooooooooooo");
        }

    }

    void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			BackToScene ();
	}

	public virtual void BackToScene ()
	{
		Application.LoadLevel (backtoScene);
	}

	public virtual void OnPrevButtonClick ()
	{
        if (alphabetIndex == fromIndex)
            alphabetIndex = toIndex;
        else
            alphabetIndex--;
        InitAlphabets();
    }

	public virtual void OnNextButtonClick ()
	{
        if (alphabetIndex >= toIndex)
            alphabetIndex = fromIndex;
        else
            alphabetIndex++;
        InitAlphabets();

    }

	protected virtual void InitAlphabets ()
	{

	}

	protected char changeAlphabet_Arabic()
	{
        return arabicAlphabet[alphabetIndex];

	}
	/// <summary>
	/// mad by Me
	/// </summary>
	/// <returns></returns>
    protected char changeAlphabet()
    {
        return alphabet[alphabetIndex];

    }
}



using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

/// <summary>
/// Class yang meng-handle minigame Letters
/// </summary>
public class AlphabetLetters : GameParent
{
    public bool isArabicText=false;

    public Button prevButton, nextButton;
    public Image upperCase, lowerCase;

    public List<AudioClip> UppercaseSound = new List<AudioClip>();
    public List<AudioClip> LowercaseSound = new List<AudioClip>();

    AudioSource audioSource;
    public Text upperCaseText, lowerCaseText;
    Animator lowerAnim, upperAnim;

    // Use this for initialization
    void Start()
    {
        if (upperCase.transform.childCount != 0)
            upperCaseText = upperCase.transform.GetChild(0).GetComponent<Text>();
        if (lowerCase.transform.childCount != 0)
            lowerCaseText = lowerCase.transform.GetChild(0).GetComponent<Text>();

        upperAnim = upperCase.GetComponent<Animator>();
        lowerAnim = lowerCase.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        InitAlphabets();
    }

    /// Method untuk meng-generate setiap huruf besar dan kecil setiap
    /// tombol Prev atau Next ditekan
    protected override void InitAlphabets()
    {
        if (isArabicText)
        {
            upperCaseText.text = ArabicFixerTool.FixLine(char.ToUpper(changeAlphabet_Arabic()).ToString());
            lowerCaseText.text = ArabicFixerTool.FixLine(char.ToLower(changeAlphabet_Arabic()).ToString());
        }
        else
        {
             upperCaseText.text = char.ToUpper(changeAlphabet()).ToString();
             lowerCaseText.text = char.ToLower(changeAlphabet()).ToString();

        }

        Invoke("playUpperCase", 0.15f);
    }
   
    //protected  void InitAlphabets_Arabic()
    //{
    //    upperCaseText.text = ArabicFixerTool.FixLine(char.ToUpper(changeAlphabet_Arabic()).ToString());
    //    lowerCaseText.text = ArabicFixerTool.FixLine(char.ToLower(changeAlphabet_Arabic()).ToString());

    //    Invoke("playUpperCase", 0.15f);
    //}


    /// Method untuk memainkan animasi dan memainkan suara untuk Huruf besar
    private void playUpperCase()
    {

        upperAnim.SetTrigger("Activate");
        audioSource.PlayOneShot(UppercaseSound[alphabetIndex]);
        Invoke("playlowerCase", 1f);
    }

    /// Method untuk memainkan animasi dan memainkan suara untuk Huruf kecil
    private void playlowerCase()
    {
        lowerAnim.SetTrigger("Activate");
        audioSource.PlayOneShot(LowercaseSound[alphabetIndex]);
    }
}

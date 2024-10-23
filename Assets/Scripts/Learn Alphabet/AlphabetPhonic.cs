

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AlphabetPhonic : GameParent
{
    public bool isArabic = false;

    public Button prevButton, nextButton;
    public Image Letter, animalImage;
    public Text nameText;
    public List<AlphabetGroup> alphabetObjet = new List<AlphabetGroup>();

    Text LetterText;
    Animator anim;
    AudioSource source;

    // Use this for initialization
    void Start()
    {
        if (Letter.transform.childCount != 0)
            LetterText = Letter.transform.GetChild(0).GetComponent<Text>();

        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        InitAlphabets();
    }

    protected override void InitAlphabets()
    {
        if (isArabic)
        {
            LetterText.text = /*char.ToUpper(changeAlphabet()) + "" +*/ char.ToLower(changeAlphabet_Arabic())+"";

        }
        else
        {
            LetterText.text = char.ToUpper(changeAlphabet()) + "" + char.ToLower(changeAlphabet());

        }

        anim.SetTrigger("Fade in");
        InitObject();
    }

    /// Method untuk meng-inisialisasi Nama, warna dari Tulisan Nama, Huruf besar dan kecil, gambar
    /// dan suara yang akan dimainkan untuk setiap object
    private void InitObject()
    {
        LetterText.text = ArabicFixerTool.FixLine(alphabetObjet[alphabetIndex].objectAlias);
        nameText.text = ArabicFixerTool.FixLine(alphabetObjet[alphabetIndex].objectName);
        nameText.color = alphabetObjet[alphabetIndex].textColor;
        animalImage.sprite = alphabetObjet[alphabetIndex].objectImage;
        source.PlayOneShot(alphabetObjet[alphabetIndex].narator);
    }
}

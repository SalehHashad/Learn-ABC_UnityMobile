using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForSwitchLanguage : MonoBehaviour
{
    public Text alphabetText;
    public Text numbersText;
    public Text headerText;





    public void SwitchBetweenLanguage(bool language)
    {
        if (language)
        {
            alphabetText.text = ArabicFixerTool.FixLine("الحروف");
            numbersText.text = ArabicFixerTool.FixLine("الارقام");
            headerText.text = ArabicFixerTool.FixLine("اختر الفئة");
        }
        else
        {
            alphabetText.text ="Alphabet";
            numbersText.text = "Numbers";
            headerText.text = "Choose The Category";

        }
    }
}



using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Script untuk meng-handle Submenu
/// </summary>
public class SubmenuControl : MonoBehaviour
{


    public Font textFont;
    public static string gotoScene;
    public Button submenuButton;
    public static SubMenuType menuType = SubMenuType.LearntoRead;
    public List<string> LearntoRead = new List<string>();
    public List<string> LearntoWrite = new List<string>();
    public List<string> Pattern = new List<string>();
    public List<string> puzzle = new List<string>();

    public List<string> LearntoRead_Arabic = new List<string>();
    public List<string> LearntoWrite_Arabic = new List<string>();
    public List<string> puzzle_Arabic = new List<string>();


    public List<string> learnNumbers_English = new List<string>();
    public List<string> learnNumbers_Arabic = new List<string>();


    public List<string> Chars = new List<string>();
    public List<string> Chars_Arabic = new List<string>();
    public bool IsCharCount = false;

    public enum SubMenuType
    {
        none = 0,
        LearntoRead = 1,
        LearntoWrite = 2,
        Pattern = 3,
        FindCorrectImage = 4,
        Puzzle = 5,
        Puzzle2 = 6,
        numbers = 7,
        englishNumbers = 8,
        arabicNumbers = 9,
    }

    void Start()
    {
        GameParent.alphabetIndex = 0;
        if (IsCharCount)
        {
            if (menuType == 0)
                Application.LoadLevel(gotoScene);
            else
            {
                switch (menuType)
                {
                    case SubMenuType.LearntoRead:
                        ButtonCloning(LearntoRead);
                        break;
                    case SubMenuType.LearntoWrite:
                        ButtonCloning(LearntoWrite);
                        break;
                    case SubMenuType.Pattern:
                        ButtonCloning(Pattern);
                        break;
                    case SubMenuType.Puzzle:
                        ButtonCloning(puzzle);
                        break;
                        //case SubMenuType.englishNumbers:
                        //    ButtonCloning(learnNumbers_English);
                        //    break;
                        //case SubMenuType.arabicNumbers:
                        //    ButtonCloning(learnNumbers_Arabic);
                        //    break;

                }
            }

            CheckScenes(MenuButtonsScript1.IS_ARABIC);

        }
        else
        {
            if (!MenuButtonsScript1.IS_NUMBERS)
            {
                if (MenuButtonsScript1.IS_ARABIC == true)
                {
                    ButtonCloningForChoices(Chars_Arabic);
                }
                else
                {
                    ButtonCloningForChoices(Chars);
                }
            }
            else
            {
                if (MenuButtonsScript1.IS_ARABIC == true)
                {
                    ButtonCloning(learnNumbers_Arabic);
                    //ButtonCloningForChoices(learnNumbers_Arabic);
                }
                else
                {
                    ButtonCloning(learnNumbers_English);
                    //ButtonCloningForChoices(learnNumbers_English);
                }

            }

        }

        //AdmobManager.bannerShow(false);
    }

    /// Method untuk meng-clone Button Submenu sesuai dengan jumlah minigame
    /// pada menu awal yang telah dipilih oleh user
    private void ButtonCloning(List<string> buttonName)
    {
        Button temp;
        for (int i = 0; i < buttonName.Count; i++)
        {
            temp = Instantiate(submenuButton, transform.position, transform.rotation) as Button;
            temp.transform.SetParent(transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = ArabicFixerTool.FixLine(buttonName[i]);

            temp.transform.GetChild(0).GetComponent<Text>().font = textFont;

            temp.gameObject.name = buttonName[i] + " Button";

            temp.GetComponent<SubmenuButtonScript>().miniGameID = i;

            //if (temp.transform.localScale == new Vector3(48, 48, 48))
            //    temp.transform.localScale = Vector3.one;

        }
    }
    private void ButtonCloningForChoices(List<string> buttonName)
    {
        Button temp;
        for (int i = 0; i < buttonName.Count; i++)
        {
            temp = Instantiate(submenuButton, transform.position, transform.rotation) as Button;
            temp.transform.SetParent(transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = ArabicFixerTool.FixLine(buttonName[i]);
            temp.transform.GetChild(0).GetComponent<Text>().font = textFont;

            temp.gameObject.name = buttonName[i] + " Button";

            int index = i;

            temp.onClick = new Button.ButtonClickedEvent();
            temp.onClick.AddListener(() => OnChooseButtonClicked(index));

            if (temp.transform.localScale == new Vector3(48, 48, 48))
                temp.transform.localScale = Vector3.one;
        }
    }

    void OnChooseButtonClicked(int i)
    {
        switch (i)
        {
            case 0:
                GameManager.Instance.fromIndex = 0;
                GameManager.Instance.toIndex = 5;
                break;
            case 1:
                GameManager.Instance.fromIndex = 6;
                GameManager.Instance.toIndex = 11;
                break;
            case 2:
                GameManager.Instance.fromIndex = 12;
                GameManager.Instance.toIndex = 17;
                break;
            case 3:
                GameManager.Instance.fromIndex = 18;
                GameManager.Instance.toIndex = 27;
                break;
        }
        ResetButtons();
        InstButtonForQuiz();
    }
    void ResetButtons()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
    }

    void InstButtonForQuiz()
    {
        // for instantiate buttons to Choose which Quiz
        GameParent.alphabetIndex = 0;

        //if (menuType == 0)
        //    Application.LoadLevel(gotoScene);
        //else
        //{
        //    switch (menuType)
        //    {
        //        case SubMenuType.LearntoRead:
        //            ButtonCloning(LearntoRead);
        //            break;
        //        case SubMenuType.LearntoWrite:
        //            ButtonCloning(LearntoWrite);
        //            break;
        //        case SubMenuType.Pattern:
        //            ButtonCloning(Pattern);
        //            break;
        //        case SubMenuType.Puzzle:
        //            ButtonCloning(puzzle);
        //            break;
        //        case SubMenuType.FindCorrectImage:
        //            Application.LoadLevel("Find the Answer");
        //            break;
        //        case SubMenuType.Puzzle2:
        //            Application.LoadLevel("Puzzle2");
        //            break;
        //    }
        //}

        CheckScenes(MenuButtonsScript1.IS_ARABIC);
    }
    void CheckScenes(bool isArabic)
    {

        //switch (menuType)
        //{
        //    case SubMenuType.numbers:
        //        if (MenuButtonsScript.IS_NUMBERS)
        //        {
        //            ButtonCloning(learnNumbers_Arabic);
        //        }
        //        else
        //        {
        //            ButtonCloning(learnNumbers_English);

        //        }
        //        break;
        //}



        if (isArabic == false)
        {
            if (menuType == 0)
                Application.LoadLevel(gotoScene);
            else
            {
                switch (menuType)
                {
                    case SubMenuType.LearntoRead:
                        ButtonCloning(LearntoRead);
                        break;
                    case SubMenuType.LearntoWrite:
                        ButtonCloning(LearntoWrite);
                        break;
                    case SubMenuType.Pattern:
                        ButtonCloning(Pattern);
                        break;
                    case SubMenuType.Puzzle:
                        ButtonCloning(puzzle);
                        break;
                    case SubMenuType.FindCorrectImage:
                        Application.LoadLevel("Find the Answer");
                        break;
                    case SubMenuType.Puzzle2:
                        Application.LoadLevel("Puzzle2");
                        break;
                    case SubMenuType.englishNumbers:
                        ButtonCloning(learnNumbers_English);
                        break;

                }
            }
        }
        else
        {
            if (menuType == 0)
                Application.LoadLevel(gotoScene);
            else
            {
                switch (menuType)
                {
                    case SubMenuType.LearntoRead:
                        ButtonCloning(LearntoRead_Arabic);
                        break;
                    case SubMenuType.LearntoWrite:
                        ButtonCloning(LearntoWrite_Arabic);
                        break;
                    case SubMenuType.Pattern:
                        ButtonCloning(Pattern);
                        break;
                    case SubMenuType.Puzzle:
                        ButtonCloning(puzzle_Arabic);
                        break;
                    case SubMenuType.FindCorrectImage:
                        Application.LoadLevel("Find the Answer2 1");
                        break;
                    case SubMenuType.Puzzle2:
                        Application.LoadLevel("Puzzle2 1");
                        break;
                    case SubMenuType.arabicNumbers:
                        ButtonCloning(learnNumbers_Arabic);
                        break;
                }
            }
        }

    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            BackToScene();
    }

    public void BackToScene()
    {
        Application.LoadLevel(Application.loadedLevel - 1);
    }

    public float getWidth()
    {
        RectTransform temp = GetComponent<RectTransform>();
        return (temp.anchorMax.x - temp.anchorMin.x) * Screen.width;
    }
}

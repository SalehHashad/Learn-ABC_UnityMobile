
using UnityEngine;
using System.Collections;

/// <summary>
/// Script untuk setiap tombol pada menu Utama
/// </summary>

public class MenuButtonsScript : MonoBehaviour
{
    public static bool IS_ARABIC;
    public static bool IS_NUMBERS;

    void Start()
    {
        IS_ARABIC = false;
        IS_NUMBERS = false;
        GameParent.alphabetIndex = 0;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnUpperButtonClick(int i)
    {
        IS_ARABIC = false;
        IS_NUMBERS = false;
        switch (i)
        {

            case 1:
                {
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.LearntoRead;
                    SubmenuControl.gotoScene = "Learn to Read";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 2:
                {
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.LearntoWrite;
                    SubmenuControl.gotoScene = "Learn to Write";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 3:
                {
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.Pattern;
                    SubmenuControl.gotoScene = "Patterns";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 4:
                {
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.FindCorrectImage;
                    SubmenuControl.gotoScene = "Find the Answer";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 5:
                {
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.Puzzle;
                    SubmenuControl.gotoScene = "Puzzle";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 6:
                {
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.Puzzle2;
                    SubmenuControl.gotoScene = "Puzzle00";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 7:
                {
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.Puzzle2;
                    SubmenuControl.gotoScene = "Quiz";
                    Application.LoadLevel("Quiz");
                }
                break;
            case 8:
                {
                    IS_ARABIC = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.FindCorrectImage;
                    SubmenuControl.gotoScene = "Find the Answer2";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 9:
                {
                    IS_ARABIC = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.LearntoRead;
                    SubmenuControl.gotoScene = "Learn to Read2";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 10:
                {
                    IS_ARABIC = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.LearntoWrite;
                    SubmenuControl.gotoScene = "Learn to Write2";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 11:
                {
                    IS_ARABIC = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.Puzzle2;
                    SubmenuControl.gotoScene = "Puzzle2";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 12:
                {
                    IS_NUMBERS = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.englishNumbers;
                    SubmenuControl.gotoScene = "Learn to Write Numbers";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 13:
                {
                    IS_ARABIC = true;
                    IS_NUMBERS = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.arabicNumbers;
                    SubmenuControl.gotoScene = "Learn to Write Numbers2";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 14:
                {
                    IS_NUMBERS = true;

                    SubmenuControl.menuType = SubmenuControl.SubMenuType.numbers;
                    SubmenuControl.gotoScene = "Puzzle Numbers English";
                    Application.LoadLevel("Puzzle Numbers English");
                }
                break;
            case 15:
                {
                    IS_NUMBERS = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.numbers;
                    SubmenuControl.gotoScene = "Puzzle Numbers Arabic";
                    Application.LoadLevel("Puzzle Numbers Arabic");
                }
                break;
            default:
                break;

                //randomChanceInterstitial();


        }
    }

    public void OnLowerButtonClick(int i)
    {
        switch (i)
        {
            case 4:
                Application.LoadLevel("Find the Answer");
                break;
            case 5:
                Application.LoadLevel("Puzzle");
                break;
            case 6:
                Application.LoadLevel("Quiz");
                break;
            case 7:
                Application.LoadLevel("Puzzle2");
                break;
        }
        //randomChanceInterstitial();
    }

    private void randomChanceInterstitial()
    {
        //		int rnd = Random.Range (0, 100);
        //		if (rnd >= 20)
        //			AdmobManager.RequestInterstitial ();
    }
    public void SetIsNumberValue()
    {
        IS_NUMBERS= true;
    }
}

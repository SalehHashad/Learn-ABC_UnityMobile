
using UnityEngine;
using System.Collections;

/// <summary>
/// Script untuk setiap tombol pada menu Utama
/// </summary>

public class MenuButtonsScript : MonoBehaviour
{
    public static bool IS_ARABIC;

    void Start()
    {
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
        switch (i)
        {
            case 1:
                {
                    IS_ARABIC = false;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.LearntoRead;
                    SubmenuControl.gotoScene = "Learn to Read";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 2:
                {
                    IS_ARABIC = false;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.LearntoWrite;
                    SubmenuControl.gotoScene = "Learn to Write";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 3:
                {
                    IS_ARABIC = false;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.Pattern;
                    SubmenuControl.gotoScene = "Patterns";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 4:
                {
                    IS_ARABIC = false;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.FindCorrectImage;
                    SubmenuControl.gotoScene = "Find the Answer";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 5:
                {
                    IS_ARABIC = false;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.Puzzle;
                    SubmenuControl.gotoScene = "Puzzle";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 6:
                {
                    IS_ARABIC = false;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.Puzzle2;
                    SubmenuControl.gotoScene = "Puzzle00";
                    Application.LoadLevel("Submenu Select");
                }
                break;
            case 7:
                {
                    IS_ARABIC = false;
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
            default:
                break;
        }
        //randomChanceInterstitial();
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
}

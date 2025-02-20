
using UnityEngine;
using System.Collections;
using Photon.Pun;

/// <summary>
/// Script untuk setiap tombol pada menu Utama
/// </summary>

public class MenuButtonsScript1 : MonoBehaviour
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
                    SubmenuControl.gotoScene = "Learn to Read 1";
                    PhotonNetwork.LoadLevel("Submenu Select 1");
                }
                break;
            case 2:
                {
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.LearntoWrite;
                    SubmenuControl.gotoScene = "Learn to Write 1";
                    PhotonNetwork.LoadLevel("Submenu Select 1");
                }
                break;
            case 3:
                {
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.Pattern;
                    SubmenuControl.gotoScene = "Patterns 1";
                    PhotonNetwork.LoadLevel("Submenu Select 1");
                }
                break;
            case 4:
                {
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.FindCorrectImage;
                    SubmenuControl.gotoScene = "Find the Answer 1";
                    PhotonNetwork.LoadLevel("Submenu Select 1");
                }
                break;
            case 5:
                {
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.Puzzle;
                    SubmenuControl.gotoScene = "Puzzle 1";
                    PhotonNetwork.LoadLevel("Submenu Select 1");
                }
                break;
            case 6:
                {
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.Puzzle2;
                    SubmenuControl.gotoScene = "Puzzle00 1";
                    PhotonNetwork.LoadLevel("Submenu Select 1");
                }
                break;
            case 7:
                {
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.Puzzle2;
                    SubmenuControl.gotoScene = "Quiz 1";
                    PhotonNetwork.LoadLevel("Quiz 1");
                }
                break;
            case 8:
                {
                    IS_ARABIC = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.FindCorrectImage;
                    SubmenuControl.gotoScene = "Find the Answer2 1";
                    PhotonNetwork.LoadLevel("Submenu Select 1");
                }
                break;
            case 9:
                {
                    IS_ARABIC = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.LearntoRead;
                    SubmenuControl.gotoScene = "Learn to Read2 1";
                    PhotonNetwork.LoadLevel("Submenu Select 1");
                }
                break;
            case 10:
                {
                    IS_ARABIC = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.LearntoWrite;
                    SubmenuControl.gotoScene = "Learn to Write2 1";
                    PhotonNetwork.LoadLevel("Submenu Select 1");
                }
                break;
            case 11:
                {
                    IS_ARABIC = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.Puzzle2;
                    SubmenuControl.gotoScene = "Puzzle2 1";
                    PhotonNetwork.LoadLevel("Submenu Select 1");
                }
                break;
            case 12:
                {
                    IS_NUMBERS = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.englishNumbers;
                    SubmenuControl.gotoScene = "Learn to Write Numbers 1";
                    PhotonNetwork.LoadLevel("Submenu Select 1");
                }
                break;
            case 13:
                {
                    IS_ARABIC = true;
                    IS_NUMBERS = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.arabicNumbers;
                    SubmenuControl.gotoScene = "Learn to Write Numbers2 1";
                    PhotonNetwork.LoadLevel("Submenu Select 1");
                }
                break;
            case 14:
                {
                    IS_NUMBERS = true;

                    SubmenuControl.menuType = SubmenuControl.SubMenuType.numbers;
                    SubmenuControl.gotoScene = "Puzzle Numbers English 1";
                    PhotonNetwork.LoadLevel("Puzzle Numbers English 1");
                }
                break;
            case 15:
                {
                    IS_NUMBERS = true;
                    SubmenuControl.menuType = SubmenuControl.SubMenuType.numbers;
                    SubmenuControl.gotoScene = "Puzzle Numbers Arabic 1";
                    PhotonNetwork.LoadLevel("Puzzle Numbers Arabic 1");
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
                PhotonNetwork.LoadLevel("Find the Answer 1");
                break;
            case 5:
                PhotonNetwork.LoadLevel("Puzzle 1");
                break;
            case 6:
                PhotonNetwork.LoadLevel("Quiz 1");
                break;
            case 7:
                PhotonNetwork.LoadLevel("Puzzle2 1");
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


using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Class yang dipasangkan pada setiap Tombol pada Submenu
/// [Lihat Component pada setiap tombol untuk lebih lengkapnya]
/// </summary>

public class SubmenuButtonScript : MonoBehaviour {
    public int miniGameID;
    public Sprite spriteButton;
    public LayoutElement layout;

    SubmenuControl parent;

    void Start()
    {
        GetComponent<Image>().sprite = spriteButton;
        layout = GetComponent<LayoutElement>();
        parent = GameObject.FindGameObjectWithTag("Submenu Parent").GetComponent<SubmenuControl>();

        layout.preferredWidth = parent.getWidth();
        layout.preferredHeight = layout.preferredWidth / 5.2f;
    }

    public void OnButtonClick()
    {
        MiniGameMaster.id = miniGameID;
        Application.LoadLevel(SubmenuControl.gotoScene);

        //AdmobManager.bannerShow(true);
    }
}

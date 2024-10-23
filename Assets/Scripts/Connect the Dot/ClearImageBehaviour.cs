
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClearImageBehaviour : MonoBehaviour
{
    public List<Sprite> clearImageList = new List<Sprite>();

    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void setClear()
    {
        image.color = new Color(255, 255, 255, .001f);
    }

    public void setVisible()
    {
        image.color = new Color(255, 255, 255, 1);
    }

    public void changeImage(int id)
    {
        image.sprite = clearImageList[id];
        setClear();
    }

    public void debugColor()
    {
        Debug.Log(image.color);
    }
}

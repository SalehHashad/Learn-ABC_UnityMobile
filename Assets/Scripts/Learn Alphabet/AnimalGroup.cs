

using UnityEngine;
using System.Collections;

/// <summary>
/// Class turunan dari AlphabetGroup yang digunakan untuk minigame
/// Animals
/// </summary>

[System.Serializable]
public class AnimalGroup : AlphabetGroup {
    public Sprite background;
    public AudioClip animalSound;

    public AnimalGroup()
    {
        objectName = "";
        objectAlias = "";
        textColor = new Color();
        objectImage = null;
        narator = null;
        animalSound = null;
    }
}

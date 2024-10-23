using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ForFixButtonNames : MonoBehaviour
{
    public string buttonName;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponentInChildren<Text>().text = ArabicFixerTool.FixLine(buttonName);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

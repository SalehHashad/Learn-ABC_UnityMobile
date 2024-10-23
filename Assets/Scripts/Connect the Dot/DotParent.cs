

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DotParent : MonoBehaviour
{
    public int parentList_id = -1;
    public Image lineConnector;
    public Transform lineParent;
    public static int currentID = -1;
    public DotSequenceManager parent;

    List<DotBehaviour> dotList = new List<DotBehaviour>();

    // Use this for initialization
    void Awake()
    {
        currentID = 1;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<DotBehaviour>().dot_ID = i;
            transform.GetChild(i).name = "Dot " + (i + 1).ToString();
            transform.GetChild(i).GetChild(0).GetComponent<Text>().text = (i + 1).ToString();

            dotList.Add(transform.GetChild(i).GetComponent<DotBehaviour>());
        }
        setAlph();
        dotList[0].status = DotStatus.isFull;
    }

    public void createLine(DotBehaviour dot)
    {
        DotBehaviour startLine = dotList[dot.dot_ID - 1];

        if (dot.dot_ID == currentID && dot.status == DotStatus.isFree)
        {
            Image temp = Instantiate(lineConnector) as Image;
            temp.transform.position = startLine.transform.position;
            temp.transform.Rotate(new Vector3(0, 0, startLine.getAngle(dot.transform.position)));
            temp.rectTransform.sizeDelta = new Vector2(startLine.getDistanceTo(dot.transform.position), 5);

            temp.name = "Line from " + startLine.dot_ID + " to " + dot.dot_ID;
            temp.transform.SetParent(lineParent);
            dot.status = DotStatus.isFull;

            currentID++;
        }
        else
        {
            parent.playSound(false);
        }

        if (currentID == transform.childCount)
            parent.correctAnswer();
    }

    private void setAlph()
    {
        int rnd = Random.Range(0, 26 - dotList.Count);

        foreach(DotBehaviour dot in dotList)
        {
            dot.transform.GetChild(0).GetComponent<Text>().text = GameParent.alphabet[rnd].ToString();
            rnd++;
        }
    }

    public void setLineParent(Transform tr)
    {
        lineParent = tr;
    }
}

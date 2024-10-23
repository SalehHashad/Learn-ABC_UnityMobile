
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DotBehaviour : MonoBehaviour,IPointerClickHandler {
    public int dot_ID = -1;
    public Sprite start, end;
    public DotStatus status;
    
    DotParent parent;

    public void Start()
    {
        parent = GetComponentInParent<DotParent>();
    }

    void Update()
    {
        if (status == DotStatus.isFree)
            GetComponent<Image>().sprite = end;
        else
            GetComponent<Image>().sprite= start;
    }

    public float getDistanceTo(Vector3 pos)
    {
        Vector2 from = new Vector2(transform.position.x, transform.position.y);
        Vector2 to = new Vector2(pos.x,pos.y);
        return Vector2.Distance(from, to);
    }

    public float getAngle(Vector3 tr)
    {
        Vector2 from = new Vector2(transform.position.x, transform.position.y);
        Vector2 to = new Vector2(tr.x, tr.y);

        return Mathf.Atan2(to.y - from.y, to.x - from.x) * Mathf.Rad2Deg;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        parent.createLine(this);
    }
}

public enum DotStatus
{
    none = -1,
    isFree = 0,
    isFull = 1
}

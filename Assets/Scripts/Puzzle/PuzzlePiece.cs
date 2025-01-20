using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour, IDragHandler, IBeginDragHandler, IDropHandler, IEndDragHandler
{
    public bool isInteractable = true;
    public Vector3 posisiAwal;
    public PuzzlePanel puzzlePanel;
    public bool isInPlace
    {
        get
        {
            return Vector3.Distance(transform.localPosition, posisiAwal) < 1;
        }
    }

    private Vector3 dragOffset;
    private GraphicRaycaster raycaster;
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;
    private void Awake()
    {
        CanvasGroup charCanvasGroup = this.gameObject.AddComponent<CanvasGroup>();
        if (charCanvasGroup)
        {
            charCanvasGroup.interactable = true;
            charCanvasGroup.blocksRaycasts = true;
        }
    }
    void Start()
    {
        raycaster = GetComponentInParent<GraphicRaycaster>();
        eventSystem = EventSystem.current;
        if (eventSystem == null)
        {
            Debug.LogError("No EventSystem found in the scene. Please add one.");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isInteractable) return;

        dragOffset = transform.position - GetVRPointerPosition(eventData);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isInteractable) return;

        transform.position = GetVRPointerPosition(eventData) + dragOffset;

        if (Vector3.Distance(transform.localPosition, posisiAwal) < puzzlePanel.puzzleManager.snapDistance)
        {
            transform.localPosition = posisiAwal;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!isInteractable) return;

        CheckPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isInteractable) return;

        puzzlePanel.CheckPieces();
    }

    private void CheckPosition()
    {
        if (Vector3.Distance(transform.localPosition, posisiAwal) < puzzlePanel.puzzleManager.snapDistance)
        {
            transform.localPosition = posisiAwal;
        }
        else
        {
            puzzlePanel.puzzleManager.PlayMockSound();
        }
    }

    private Vector3 GetVRPointerPosition(PointerEventData eventData)
    {
        // Use the event camera (VR camera) to get the pointer position in world space
        Vector3 pointerPosition;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            transform.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out pointerPosition
        );
        return pointerPosition;
    }
}
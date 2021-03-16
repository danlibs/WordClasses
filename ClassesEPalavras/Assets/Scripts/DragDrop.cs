using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public bool isPositioned = false;
    public bool isDragging;

    [SerializeField]
    private Canvas canvas;
    private Vector2 initialPosition;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Color mouseOverColor = Color.yellow;
    private Color baseColor = Color.white;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initialPosition = transform.position;
    }

    private void Start()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
    }

    private void Update()
    {
        if (isPositioned)
        {
            transform.position = initialPosition;
            GetComponentInChildren<Word>().UpdateWord();
            isPositioned = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        WordClassBox.draggedObject = eventData.pointerDrag.GetComponent<DragDrop>();
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        WordClassBox.draggedObject = null;
        isDragging = false;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    
}

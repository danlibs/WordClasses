using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WordClassBox : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private GameManager gameManager;
    private RectTransform rectTransform;
    private Word wordPlaced;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
            wordPlaced = eventData.pointerDrag.GetComponentInChildren<Word>();
            
            if (tag == "Noum" && wordPlaced.isNoum)
            {
                gameManager.points += 2;
                gameManager.UpdatePoints();
            }
        }
        
    }

}

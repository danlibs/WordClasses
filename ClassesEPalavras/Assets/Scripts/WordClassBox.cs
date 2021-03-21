using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class WordClassBox : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static DragDrop draggedObject;

    [SerializeField]
    private GameDirector gameManager;
    [SerializeField]
    private PointsMultiplier pointsManager;
    [SerializeField]
    private GameObject pointsAndTimeGainedText;

    private RectTransform rectTransform;
    private Word wordPlaced;
    private Color mouseOverColor = Color.yellow;
    private Color baseColor = Color.white;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        pointsAndTimeGainedText = GameObject.FindGameObjectWithTag("TextPointsAndTime");
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
            wordPlaced = eventData.pointerDrag.GetComponentInChildren<Word>();
            draggedObject = wordPlaced.GetComponentInParent<DragDrop>();
            pointsAndTimeGainedText.GetComponent<RectTransform>().localPosition = rectTransform.localPosition;

            CheckWordAndClass();
            StartTextForPointsAndTimeGained();
            wordPlaced.GetComponentInParent<DragDrop>().isPositioned = true;
            GetComponent<Image>().color = baseColor;
        }
    }

    private void CheckWordAndClass()
    {
        if (wordPlaced != null)
        {
            TextMeshProUGUI timeAndPoints = pointsAndTimeGainedText.GetComponent<TextMeshProUGUI>();
            
            var keyNames = wordPlaced.classes.Where(s => s.Value == true).Select(s => s.Key).ToList();
            if (keyNames.Contains(tag))
            {
                gameManager.points += pointsManager.GainPoints();
                pointsManager.correctAnswers += 1;
                timeAndPoints.color = Color.blue;
                if (wordPlaced.isTimeWord) gameManager.timeRemaining += 10; else gameManager.timeRemaining += 1;
                if (wordPlaced.isTimeWord)
                {
                    timeAndPoints.text = "+" + pointsManager.GainPoints() + " pts \n +10 seg";
                }
                else
                {
                    timeAndPoints.text = "+" + pointsManager.GainPoints() + " pts \n +1 seg";
                }
                gameManager.UpdatePoints();
            }
            else
            {
                gameManager.timeRemaining -= 3;
                pointsManager.correctAnswers = 0;
                timeAndPoints.color = Color.red;
                timeAndPoints.text = "-3 seg";
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (draggedObject != null)
        {
            if (draggedObject.isDragging)
            {
                GetComponent<Image>().color = mouseOverColor;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = baseColor;               
    }

    private void StartTextForPointsAndTimeGained()
    {
        pointsAndTimeGainedText.GetComponent<TextMeshProUGUI>().alpha = 255;
        pointsAndTimeGainedText.GetComponent<Animation>().Play();
    }
}

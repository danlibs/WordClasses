using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WordClassBox : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static DragDrop draggedObject;

    [SerializeField]
    private GameDirector gameManager;

    private RectTransform rectTransform;
    private Word wordPlaced;
    private Color mouseOverColor = Color.yellow;
    private Color baseColor = Color.white;

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
            draggedObject = wordPlaced.GetComponentInParent<DragDrop>();

            CheckWordAndClass();
            wordPlaced.GetComponentInParent<DragDrop>().isPositioned = true;
            GetComponent<Image>().color = baseColor;
        }
    }

    private void CheckWordAndClass()
    {
        if (wordPlaced != null)
        {
            //Verify nouns
            if (tag == "Noum")
            {
                if (wordPlaced.classes["noum"])
                {
                    gameManager.points += 2;
                    gameManager.timeRemaining += 1;
                    gameManager.UpdatePoints();
                }
                else
                {
                    gameManager.timeRemaining -= 3;
                }
            }

            //Verify adjectives
            if (tag == "Adjective")
            {
                if (wordPlaced.classes["adjective"])
                {
                    gameManager.points += 2;
                    gameManager.timeRemaining += 1;
                    gameManager.UpdatePoints();
                }
                else
                {
                    gameManager.timeRemaining -= 3;
                }
            }

            //Verify adverbs
            if (tag == "Adverb")
            {
                if (wordPlaced.classes["adverb"])
                {
                    gameManager.points += 2;
                    gameManager.timeRemaining += 1;
                    gameManager.UpdatePoints();
                }
                else
                {
                    gameManager.timeRemaining -= 3;
                }
            }

            //Verify articles
            if (tag == "Article")
            {
                if (wordPlaced.classes["article"])
                {
                    gameManager.points += 2;
                    gameManager.timeRemaining += 1;
                    gameManager.UpdatePoints();
                }
                else
                {
                    gameManager.timeRemaining -= 3;
                }
            }

            //Verify numerals
            if (tag == "Numeral")
            {
                if (wordPlaced.classes["numeral"])
                {
                    gameManager.points += 2;
                    gameManager.timeRemaining += 1;
                    gameManager.UpdatePoints();
                }
                else
                {
                    gameManager.timeRemaining -= 3;
                }
            }

            //Verify pronouns
            if (tag == "Pronoum")
            {
                if (wordPlaced.classes["pronoum"])
                {
                    gameManager.points += 2;
                    gameManager.timeRemaining += 1;
                    gameManager.UpdatePoints();
                }
                else
                {
                    gameManager.timeRemaining -= 3;
                }
            }

            //Verify preposition
            if (tag == "Preposition")
            {
                if (wordPlaced.classes["preposition"])
                {
                    gameManager.points += 2;
                    gameManager.timeRemaining += 1;
                    gameManager.UpdatePoints();
                }
                else
                {
                    gameManager.timeRemaining -= 3;
                }
            }

            //Verify interjections
            if (tag == "Interjection")
            {
                if (wordPlaced.classes["interjection"])
                {
                    gameManager.points += 2;
                    gameManager.timeRemaining += 1;
                    gameManager.UpdatePoints();
                }
                else
                {
                    gameManager.timeRemaining -= 3;
                }
            }

            //Verify verbs
            if (tag == "Verb")
            {
                if (wordPlaced.classes["verb"])
                {
                    gameManager.points += 2;
                    gameManager.timeRemaining += 1;
                    gameManager.UpdatePoints();
                }
                else
                {
                    gameManager.timeRemaining -= 3;
                }
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
}

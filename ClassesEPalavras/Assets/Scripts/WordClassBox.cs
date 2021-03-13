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

            CheckWordAndClass();
            wordPlaced.GetComponentInParent<DragDrop>().isPositioned = true;
        }
    }

    private void CheckWordAndClass()
    {
        if (wordPlaced != null)
        {
            //Verify nouns
            if (tag == "Noum")
            {
                if (wordPlaced.isNoum)
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
                if (wordPlaced.isAdjective)
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
                if (wordPlaced.isAdverb)
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
                if (wordPlaced.isArticle)
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
                if (wordPlaced.isNumeral)
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
                if (wordPlaced.isPronoum)
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
                if (wordPlaced.isPreposition)
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
                if (wordPlaced.isInterjection)
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
                if (wordPlaced.isVerb)
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

}

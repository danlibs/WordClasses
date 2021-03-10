using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Word : MonoBehaviour
{
    public bool isNoum;
    public bool isAdjective;
    public bool isAdverb;
    public bool isArticle;
    public bool isPronoum;
    public bool isNumeral;
    public bool isVerb;
    public bool isInterjection;
    public bool isPreposition;

    private TMP_Text text; 
    [SerializeField]
    private string[] nouns;
    [SerializeField]
    private string[] adjectives;
    [SerializeField]
    private string[] adverbs;
    [SerializeField]
    private string[] articles;
    [SerializeField]
    private string[] pronouns;
    [SerializeField]
    private string[] numerals;
    [SerializeField]
    private string[] verbs;
    [SerializeField]
    private string[] interjections;
    [SerializeField]
    private string[] prepositions;

    private int randomClass;
    private string randomWord;

    private void Start()
    {
        randomClass = Random.Range(1, 9);
        ClassSelect();

        GetComponent<TextMeshProUGUI>().text = WordSelect(randomClass);
       
    }

    private void ClassSelect()
    {
        switch (randomClass)
        {
            case 1:
                isNoum = true;
                break;
            case 2:
                isAdjective = true;
                break;
            case 3:
                isAdverb = true;
                break;
            case 4:
                isArticle = true;
                break;
            case 5:
                isPronoum = true;
                break;
            case 6:
                isNumeral = true;
                break;
            case 7:
                isVerb = true;
                break;
            case 8:
                isPreposition = true;
                break;
            case 9:
                isInterjection = true;
                
                break;
        }
    }

    private string WordSelect(int randomClass)
    {
        if (randomClass == 1)
        {
            randomWord = nouns[Random.Range(0, nouns.Length)];
        } 
        else if (randomClass == 2)
        {
            randomWord = adjectives[Random.Range(0, adjectives.Length)];
        }
        else if (randomClass == 3)
        {
            randomWord = adverbs[Random.Range(0, adverbs.Length)];
        }
        else if (randomClass == 4)
        {
            randomWord = articles[Random.Range(0, articles.Length)];
        }
        else if (randomClass == 5)
        {
            randomWord = pronouns[Random.Range(0, pronouns.Length)];
        }
        else if (randomClass == 6)
        {
            randomWord = numerals[Random.Range(0, numerals.Length)];
        }
        else if (randomClass == 7)
        {
            randomWord = verbs[Random.Range(0, verbs.Length)];
        }
        else if (randomClass == 8)
        {
            randomWord = prepositions[Random.Range(0, prepositions.Length)];
        }
        else if (randomClass == 9)
        {
            randomWord = interjections[Random.Range(0, interjections.Length)];
        }

        return randomWord;
    }

    
}

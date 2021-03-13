using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public int randomClass;

    [SerializeField]
    private TextAsset nouns;
    [SerializeField]
    private TextAsset adjectives;
    [SerializeField]
    private TextAsset adverbs;
    [SerializeField]
    private TextAsset articles;
    [SerializeField]
    private TextAsset pronouns;
    [SerializeField]
    private TextAsset numerals;
    [SerializeField]
    private TextAsset verbs;
    [SerializeField]
    private TextAsset interjections;
    [SerializeField]
    private TextAsset prepositions;

    private string randomWord;

    private void Start()
    {
        randomClass = Random.Range(1, 9);
        //randomClass = 1;
        ClassSelect();
        GetComponent<TextMeshProUGUI>().text = WordSelect(randomClass);
    }

    public void ClassSelect()
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

    public string WordSelect(int randomClass)
    {
        if (randomClass == 1)
        {
            randomWord = WordGetter.TextToList(nouns)[Random.Range(0, WordGetter.TextToList(nouns).Count)];
        } 
        else if (randomClass == 2)
        {
            randomWord = WordGetter.TextToList(adjectives)[Random.Range(0, WordGetter.TextToList(adjectives).Count)];
        }
        else if (randomClass == 3)
        {
            randomWord = WordGetter.TextToList(adverbs)[Random.Range(0, WordGetter.TextToList(adverbs).Count)];
        }
        else if (randomClass == 4)
        {
            randomWord = WordGetter.TextToList(articles)[Random.Range(0, WordGetter.TextToList(articles).Count)];
        }
        else if (randomClass == 5)
        {
            randomWord = WordGetter.TextToList(pronouns)[Random.Range(0, WordGetter.TextToList(pronouns).Count)];
        }
        else if (randomClass == 6)
        {
            randomWord = WordGetter.TextToList(numerals)[Random.Range(0, WordGetter.TextToList(numerals).Count)];
        }
        else if (randomClass == 7)
        {
            randomWord = WordGetter.TextToList(verbs)[Random.Range(0, WordGetter.TextToList(verbs).Count)];
        }
        else if (randomClass == 8)
        {
            randomWord = WordGetter.TextToList(prepositions)[Random.Range(0, WordGetter.TextToList(prepositions).Count)];
        }
        else if (randomClass == 9)
        {
            randomWord = WordGetter.TextToList(interjections)[Random.Range(0, WordGetter.TextToList(interjections).Count)];
        }

        return randomWord;
    }

    public void UpdateWord()
    {
        randomClass = Random.Range(1, 9);
        ClassSelect();
        GetComponent<TextMeshProUGUI>().text = WordSelect(randomClass);
    }

}

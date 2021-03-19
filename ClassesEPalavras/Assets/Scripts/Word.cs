using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Word : MonoBehaviour
{
    public Dictionary<string, bool> classes;
    public int randomClass;

    [SerializeField]
    private TextAsset nouns;
    [SerializeField]
    private TextAsset adjectives;
    [SerializeField]
    private TextAsset adverbs;
    [SerializeField]
    private TextAsset articles;
    private List<string> articlesList;
    [SerializeField]
    private TextAsset pronouns;
    private List<string> pronounsList;
    [SerializeField]
    private TextAsset numerals;
    private List<string> numeralsList;
    [SerializeField]
    private TextAsset verbs;
    [SerializeField]
    private TextAsset interjections;
    [SerializeField]
    private TextAsset prepositions;
    private List<string> prepositionsList;
    [SerializeField]
    private TextAsset conjunctions;

    private string randomWord;

    private void Awake()
    {
        articlesList = WordGetter.TextToList(articles);
        prepositionsList = WordGetter.TextToList(prepositions);
        pronounsList = WordGetter.TextToList(pronouns);
        numeralsList = WordGetter.TextToList(numerals);
    }

    private void Start()
    {
        InitiateClasses();
        randomClass = Random.Range(0, 10);
        ClassSelect();
        GetComponent<TextMeshProUGUI>().text = WordSelect(randomClass);
    }

    public void ClassSelect()
    {
        switch (randomClass)
        {
            case 0:
                classes["noum"] = true;
                break;
            case 1:
                classes["adjective"] = true;
                break;
            case 2:
                classes["adverb"] = true;
                break;
            case 3:
                classes["article"] = true;
                break;
            case 4:
                classes["pronoum"] = true;
                break;
            case 5:
                classes["numeral"] = true;
                break;
            case 6:
                classes["verb"] = true;
                break;
            case 7:
                classes["preposition"] = true;
                break;
            case 8:
                classes["interjection"] = true;
                break;
            case 9:
                classes["conjunction"] = true;
                break;
        }
    }

    public string WordSelect(int randomClass)
    {
        if (randomClass == 0)
        {
            randomWord = WordGetter.TextToList(nouns)[Random.Range(0, WordGetter.TextToList(nouns).Count)];
        } 
        else if (randomClass == 1)
        {
            randomWord = WordGetter.TextToList(adjectives)[Random.Range(0, WordGetter.TextToList(adjectives).Count)];
        }
        else if (randomClass == 2)
        {
            randomWord = WordGetter.TextToList(adverbs)[Random.Range(0, WordGetter.TextToList(adverbs).Count)];
        }
        else if (randomClass == 3)
        {
            randomWord = WordGetter.TextToList(articles)[Random.Range(0, WordGetter.TextToList(articles).Count)];
            if (prepositionsList.Contains(randomWord))
            {
                classes["preposition"] = true;
            }
            if (pronounsList.Contains(randomWord))
            {
                classes["pronoum"] = true;
            }
            if (numeralsList.Contains(randomWord))
            {
                classes["numeral"] = true;
            }
        }
        else if (randomClass == 4)
        {
            randomWord = WordGetter.TextToList(pronouns)[Random.Range(0, WordGetter.TextToList(pronouns).Count)];
            if (articlesList.Contains(randomWord))
            {
                classes["article"] = true;
            }
            if (prepositionsList.Contains(randomWord))
            {
                classes["preposition"] = true;
            }
        }
        else if (randomClass == 5)
        {
            randomWord = WordGetter.TextToList(numerals)[Random.Range(0, WordGetter.TextToList(numerals).Count)];
            if (articlesList.Contains(randomWord))
            {
                classes["article"] = true;
            }
        }
        else if (randomClass == 6)
        {
            randomWord = WordGetter.TextToList(verbs)[Random.Range(0, WordGetter.TextToList(verbs).Count)];
        }
        else if (randomClass == 7)
        {
            randomWord = WordGetter.TextToList(prepositions)[Random.Range(0, WordGetter.TextToList(prepositions).Count)];
            if (articlesList.Contains(randomWord))
            {
                classes["article"] = true;
            }
            if (pronounsList.Contains(randomWord))
            {
                classes["pronoum"] = true;
            }
        }
        else if (randomClass == 8)
        {
            randomWord = WordGetter.TextToList(interjections)[Random.Range(0, WordGetter.TextToList(interjections).Count)];
        }
        else if (randomClass == 9)
        {
            randomWord = WordGetter.TextToList(conjunctions)[Random.Range(0, WordGetter.TextToList(conjunctions).Count)];
        }

        return randomWord;
    }

    public void UpdateWord()
    {
        TurnAllValuesFalse();
        randomClass = Random.Range(0, 10);
        ClassSelect();
        GetComponent<TextMeshProUGUI>().text = WordSelect(randomClass);
    }

    private void InitiateClasses()
    {
        classes = new Dictionary<string, bool> 
        {
            {"noum", false},
            {"adjective", false},
            {"adverb", false},
            {"article", false},
            {"numeral", false},
            {"pronoum", false},
            {"verb", false},
            {"interjection", false},
            {"preposition", false},
            {"conjunction", false}
        };
    }

    private Dictionary<string, bool> TurnAllValuesFalse()
    {
        string[] classKeys = new string[classes.Count];
        classes.Keys.CopyTo(classKeys, 0);
        
        for (int i = 0; i < classes.Count; i++)
        {
            classes[classKeys[i]] = false;
        }
        return classes;
    }

}

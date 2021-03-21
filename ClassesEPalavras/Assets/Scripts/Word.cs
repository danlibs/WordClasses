using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Word : MonoBehaviour
{
    public Dictionary<string, bool> classes;
    public int randomClass;
    public bool isTimeWord;

    [SerializeField]
    private TextAsset nouns;
    [SerializeField]
    private TextAsset noumSentences;
    [SerializeField]
    private TextAsset adjectives;
    [SerializeField]
    private TextAsset adjectiveSentences;
    [SerializeField]
    private TextAsset adverbs;
    [SerializeField]
    private TextAsset adverbSentences;
    [SerializeField]
    private TextAsset articles;
    [SerializeField]
    private TextAsset articleSentences;
    [SerializeField]
    private TextAsset pronouns;
    [SerializeField]
    private TextAsset pronoumSentences;
    [SerializeField]
    private TextAsset numerals;
    [SerializeField]
    private TextAsset numeralSentences;
    [SerializeField]
    private TextAsset verbs;
    [SerializeField]
    private TextAsset verbSentences;
    [SerializeField]
    private TextAsset interjections;
    [SerializeField]
    private TextAsset interjectionSentences;
    [SerializeField]
    private TextAsset prepositions;
    [SerializeField]
    private TextAsset prepositionSentences;
    [SerializeField]
    private TextAsset conjunctions;
    [SerializeField]
    private TextAsset conjunctionSentences;

    private List<string> pronounsList;
    private List<string> numeralsList;
    private List<string> prepositionsList;
    private List<string> articlesList;
    private string randomWord;
    private TextMeshProUGUI wordText;

    private void Awake()
    {
        articlesList = WordGetter.TextToList(articles);
        prepositionsList = WordGetter.TextToList(prepositions);
        pronounsList = WordGetter.TextToList(pronouns);
        numeralsList = WordGetter.TextToList(numerals);
        wordText = GetComponent<TextMeshProUGUI>();
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
                classes["Noum"] = true;
                break;
            case 1:
                classes["Adjective"] = true;
                break;
            case 2:
                classes["Adverb"] = true;
                break;
            case 3:
                classes["Article"] = true;
                break;
            case 4:
                classes["Pronoum"] = true;
                break;
            case 5:
                classes["Numeral"] = true;
                break;
            case 6:
                classes["Verb"] = true;
                break;
            case 7:
                classes["Preposition"] = true;
                break;
            case 8:
                classes["Interjection"] = true;
                break;
            case 9:
                classes["Conjunction"] = true;
                break;
        }
    }

    public string WordSelect(int randomClass)
    {
        if (randomClass == 0)
        {
            if (GameDirector.spawnState == GameDirector.SpawnState.Word) randomWord = WordGetter.TextToList(nouns)[Random.Range(0, WordGetter.TextToList(nouns).Count)];
            if (GameDirector.spawnState == GameDirector.SpawnState.Sentence) randomWord = WordGetter.TextToList(noumSentences)[Random.Range(0, WordGetter.TextToList(nouns).Count)];
        } 
        else if (randomClass == 1)
        {
            if (GameDirector.spawnState == GameDirector.SpawnState.Word) randomWord = WordGetter.TextToList(adjectives)[Random.Range(0, WordGetter.TextToList(adjectives).Count)];
            if (GameDirector.spawnState == GameDirector.SpawnState.Sentence) randomWord = WordGetter.TextToList(adjectiveSentences)[Random.Range(0, WordGetter.TextToList(adjectiveSentences).Count)];
        }
        else if (randomClass == 2)
        {
            if (GameDirector.spawnState == GameDirector.SpawnState.Word) randomWord = WordGetter.TextToList(adverbs)[Random.Range(0, WordGetter.TextToList(adverbs).Count)];
            if (GameDirector.spawnState == GameDirector.SpawnState.Sentence) randomWord = WordGetter.TextToList(adverbSentences)[Random.Range(0, WordGetter.TextToList(adverbSentences).Count)];
        }
        else if (randomClass == 3)
        {
            if (GameDirector.spawnState == GameDirector.SpawnState.Word) randomWord = WordGetter.TextToList(articles)[Random.Range(0, WordGetter.TextToList(articles).Count)];
            if (GameDirector.spawnState == GameDirector.SpawnState.Sentence) randomWord = WordGetter.TextToList(articleSentences)[Random.Range(0, WordGetter.TextToList(articleSentences).Count)];
            if (prepositionsList.Contains(randomWord))
            {
                classes["Preposition"] = true;
            }
            if (pronounsList.Contains(randomWord))
            {
                classes["Pronoum"] = true;
            }
            if (numeralsList.Contains(randomWord))
            {
                classes["Numeral"] = true;
            }
        }
        else if (randomClass == 4)
        {
            if (GameDirector.spawnState == GameDirector.SpawnState.Word) randomWord = WordGetter.TextToList(pronouns)[Random.Range(0, WordGetter.TextToList(pronouns).Count)];
            if (GameDirector.spawnState == GameDirector.SpawnState.Sentence) randomWord = WordGetter.TextToList(pronoumSentences)[Random.Range(0, WordGetter.TextToList(pronoumSentences).Count)];
            if (articlesList.Contains(randomWord))
            {
                classes["Article"] = true;
            }
            if (prepositionsList.Contains(randomWord))
            {
                classes["Preposition"] = true;
            }
        }
        else if (randomClass == 5)
        {
            if (GameDirector.spawnState == GameDirector.SpawnState.Word) randomWord = WordGetter.TextToList(numerals)[Random.Range(0, WordGetter.TextToList(numerals).Count)];
            if (GameDirector.spawnState == GameDirector.SpawnState.Sentence) randomWord = WordGetter.TextToList(numeralSentences)[Random.Range(0, WordGetter.TextToList(numeralSentences).Count)];
            if (articlesList.Contains(randomWord))
            {
                classes["Article"] = true;
            }
        }
        else if (randomClass == 6)
        {
            if (GameDirector.spawnState == GameDirector.SpawnState.Word) randomWord = WordGetter.TextToList(verbs)[Random.Range(0, WordGetter.TextToList(verbs).Count)];
            if (GameDirector.spawnState == GameDirector.SpawnState.Sentence) randomWord = WordGetter.TextToList(verbSentences)[Random.Range(0, WordGetter.TextToList(verbSentences).Count)];
        }
        else if (randomClass == 7)
        {
            if (GameDirector.spawnState == GameDirector.SpawnState.Word) randomWord = WordGetter.TextToList(prepositions)[Random.Range(0, WordGetter.TextToList(prepositions).Count)];
            if (GameDirector.spawnState == GameDirector.SpawnState.Sentence) randomWord = WordGetter.TextToList(prepositionSentences)[Random.Range(0, WordGetter.TextToList(prepositionSentences).Count)];
            if (articlesList.Contains(randomWord))
            {
                classes["Article"] = true;
            }
            if (pronounsList.Contains(randomWord))
            {
                classes["Pronoum"] = true;
            }
        }
        else if (randomClass == 8)
        {
            if (GameDirector.spawnState == GameDirector.SpawnState.Word) randomWord = WordGetter.TextToList(interjections)[Random.Range(0, WordGetter.TextToList(interjections).Count)];
            if (GameDirector.spawnState == GameDirector.SpawnState.Sentence) randomWord = WordGetter.TextToList(interjectionSentences)[Random.Range(0, WordGetter.TextToList(interjectionSentences).Count)];
        }
        else if (randomClass == 9)
        {
            if (GameDirector.spawnState == GameDirector.SpawnState.Word) randomWord = WordGetter.TextToList(conjunctions)[Random.Range(0, WordGetter.TextToList(conjunctions).Count)];
            if (GameDirector.spawnState == GameDirector.SpawnState.Sentence) randomWord = WordGetter.TextToList(conjunctionSentences)[Random.Range(0, WordGetter.TextToList(conjunctionSentences).Count)];
        }

        return randomWord;
    }

    public void UpdateWord()
    {
        TurnAllValuesFalse();
        /*foreach (var item in classes)
        {
            Debug.Log("Classe: "+ item.Key.ToString() + "\n Valor: "+ item.Value.ToString());
        }*/
        randomClass = Random.Range(0, 10);
        ClassSelect();
        CreateNormalWordOrTimeWord();
    }

    private void CreateNormalWordOrTimeWord()
    {
        int numberToTimeWord = Random.Range(1, 101);
        if (numberToTimeWord <= 5)
        {
            wordText.color = Color.blue; 
            wordText.text = WordSelect(randomClass);
            isTimeWord = true;
        }
        else
        {
            wordText.color = Color.white;
            wordText.text = WordSelect(randomClass);
            isTimeWord = false;
        }
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

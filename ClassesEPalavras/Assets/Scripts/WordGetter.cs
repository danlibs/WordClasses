using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WordGetter 
{
    public static List<string> TextToList(TextAsset ta)
    {
        return new List<string>(ta.text.Split('\n'));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject word;
    private Canvas canvas;

    private void Start()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
        SpawnWord();
    }

    private void SpawnWord()
    {
        Instantiate(word, transform.position, Quaternion.identity, canvas.transform);
    }
}

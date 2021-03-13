using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public bool isActive;

    [SerializeField]
    private GameObject word;
    private Canvas canvas;

    private void Start()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
        SpawnWord();
    }

    public void SpawnWord()
    {
        Instantiate(word, transform.position, Quaternion.identity, canvas.transform);
    }
}

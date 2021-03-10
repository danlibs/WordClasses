using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject word;
    private Vector3 position;
    private Canvas canvas;

    private void Awake()
    {
        position = transform.position;
    }

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

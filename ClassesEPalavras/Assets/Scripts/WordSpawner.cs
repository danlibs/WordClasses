using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public bool isActive;

    [SerializeField]
    private GameObject word;
    private Canvas canvas;
    [SerializeField]
    private bool instatiated;

    private void Start()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
    }

    private void Update()
    {
        if (isActive)
        {
            if (!instatiated)
            {
                SpawnWord();
                instatiated = true;
            }
        }
        else
        {
            instatiated = false;
        }
    }

    public void SpawnWord()
    {
        Instantiate(word, transform.position, Quaternion.identity, transform);
    }
}

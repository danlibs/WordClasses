using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyConfigurationsButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        button.onClick.AddListener(delegate { SaveChanges(); });
    }

    private void SaveChanges()
    {
        gameManager.SaveConfigurations();
    }
}

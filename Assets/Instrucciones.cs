﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instrucciones : MonoBehaviour
{
    public static Instrucciones Instance { private set; get; }

    [SerializeField]
    Button firstButton;

    private void Awake()
    {
        Instance = this;
        transform.localScale = Vector3.zero;
        
    }

    public void Show()
    {
        transform.localScale = Vector3.one;
        firstButton.Select();
    }

    public void Hide()
    {
            PauseMenu.Instance.Show();
            FindObjectOfType<MainMenuScript>().FocusButton();
            transform.localScale = Vector3.zero;

            
    }
}

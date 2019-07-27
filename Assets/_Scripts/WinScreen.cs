﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public static WinScreen Instance { private set; get; }

    [SerializeField]
    Button firstButton;

    [SerializeField]
    TMP_Text label;

    void Awake()
    {
        Instance = this;
        transform.localScale = Vector3.zero;
    }
    
    void Update()
    {
        
    }

    public void Show(int player)
    {
        transform.DOScale(1, 0.25f);
        if (ScenesManager.Instance.IsJoystickConnected())
            firstButton.Select();

        label.text = "GANA EL JUGADOR " + player;

    }

    public void Hide()
    {
        transform.DOScaleY(0, 0.25f);
        //Reiniciar partida
    }

    public void PlayAgain()
    {
        ScenesManager.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        ScenesManager.Instance.LoadScene(0);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField]
    Button[] buttons;

    private void Start()
    {
        if (ScenesManager.Instance.IsJoystickConnected())
            buttons[0].Select();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void FocusButton()
    {
        buttons[0].Select();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && ScenesManager.Instance.IsJoystickConnected())
            buttons[0].Select();
    }
    
    public void StartGameButton()
    {
        Instrucciones.Instance.Show();
    }

    public void StartGame()
    {
        ScenesManager.Instance.LoadScene(1);
    }

    public void CreditsButton()
    {
        ScenesManager.Instance.LoadScene(2, Color.black);
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
    }
}

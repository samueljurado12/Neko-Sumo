using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        if (Input.GetButtonDown("StartButton"))
        {
            PauseMenu.Instance.SwitchMenu();
        }
    }
}

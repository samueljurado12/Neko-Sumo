using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetButtonDown("StartButton"))
        {
            PauseMenu.Instance.SwitchMenu();
        }
    }
}

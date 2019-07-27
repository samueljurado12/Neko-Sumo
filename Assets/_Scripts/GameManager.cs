using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { private set; get; }

    private void Awake()
    {
        Instance = this;
    }

    public CharacterMovement player1, player2;

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

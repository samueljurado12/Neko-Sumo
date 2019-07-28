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

    void Update()
    {
        if (Input.GetButtonDown("StartButton"))
        {
            PauseMenu.Instance.SwitchMenu();
        }

        if (Vector2.Distance(player1.transform.position, player2.transform.position) < 2)
        {
            player1.AddForce(-10);
            player2.AddForce(-10);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        /*
        player1.PauseCat();
        player2.PauseCat();
        player1.enabled = false;
        player2.enabled = false;
        PlatformManager.Instance.GetComponent<Rigidbody2D>().simulated = false;*/
    }

    public void Resume()
    {
        Time.timeScale = 1;
        /*
        player1.ResumeCat();
        player2.ResumeCat();
        player1.enabled = true;
        player2.enabled = true;
        PlatformManager.Instance.GetComponent<Rigidbody2D>().simulated = true;*/
    }
}

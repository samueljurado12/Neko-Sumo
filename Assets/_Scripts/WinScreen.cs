using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public static WinScreen Instance { private set; get; }

    [SerializeField]
    Button firstButton;

    [SerializeField]
    TMP_Text label;

    [SerializeField]
    Image belt;

    [SerializeField]
    private Color red, blue;

    void Awake()
    {
        Instance = this;
        transform.localScale = Vector3.zero;
    }
    
    void Update()
    {
        
    }

    public void Show(int playerNumber)
    {
        transform.localScale = Vector3.one;
        //transform.DOScale(1, 0.25f);
        if (ScenesManager.Instance.IsJoystickConnected())
            firstButton.Select();

        if (playerNumber == 1)
            label.text = "GANA EL JUGADOR ROJO";
        if (playerNumber == 2)
            label.text = "GANA EL JUGADOR AZUL";

        Debug.Log("cambio de color");
        belt.color = playerNumber == 1 ? red : blue;

    }

    public void Hide()
    {
        transform.localScale = Vector3.zero;
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

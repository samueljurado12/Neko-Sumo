using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ReturnConfirmation : MonoBehaviour
{
    public static ReturnConfirmation Instance { private set; get; }

    [SerializeField]
    Button firstButton;

    void Awake()
    {
        Instance = this;
        transform.localScale = Vector3.zero;
    }
    
    void Update()
    {
        
    }

    public void Show()
    {
        transform.DOScale(1, 0.25f);
        if (ScenesManager.Instance.IsJoystickConnected())
            firstButton.Select();
    }

    public void Hide()
    {
        transform.DOScaleY(0, 0.25f);
        PauseMenu.Instance.Show();
    }

    public void LoadMainMenu()
    {
        ScenesManager.Instance.LoadScene(0);
    }
}

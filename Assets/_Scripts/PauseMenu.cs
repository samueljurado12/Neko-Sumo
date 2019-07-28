using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    Button firstButton;

    static PauseMenu _instance;
    public static PauseMenu Instance { private set { _instance = value; }
        get
        {
            if (_instance == null)
            {
                GameObject instance = Instantiate((GameObject)Resources.Load("PauseMenu"));
            }
            return _instance;
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    
    public void Start()
    {
        transform.localScale = Vector3.right;
        
    }

    public void SwitchMenu()
    {
        if (!visible)
        {
            Show();
        }
        else
        {
            ContinueButton();
            
        }
    }

    bool visible;

    public void Show()
    {
        //transform.DOScaleY(1, 0.1f).OnComplete(() => FocusButton());
        transform.localScale = Vector3.one;
        FocusButton();
        GameManager.Instance.Pause();
        visible = true;
    }

    void FocusButton()
    {
        if (ScenesManager.Instance.IsJoystickConnected())
        {
            GetComponentInChildren<Button>().Select();
            
        }

    }

    public void Hide()
    {
        //transform.DOScaleY(0, 0.1f);
        transform.localScale = Vector3.zero;
    }

    public void ContinueButton()
    {
        Hide();
        visible = false;
        StartCoroutine(Cor());

    }

    IEnumerator Cor()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        GameManager.Instance.Resume();
    }

    public void InstructionsButtons()
    {
        Instrucciones.Instance.Show();
        Hide();
    }

    public void MenuButton()
    {
        Hide();
        ReturnConfirmation.Instance.Show();
    }
}

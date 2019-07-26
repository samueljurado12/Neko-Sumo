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
            /*if (_instance == null)
            {
                GameObject instance = Instantiate((GameObject)Resources.Load("PauseMenu"));

            }*/
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
            visible = true;
        }
        else
        {
            ContinueButton();
            visible = false;
        }
    }

    bool visible;

    public void Show()
    {
        transform.DOScaleY(1, 0.1f).OnComplete(() => GetComponentInChildren<Button>().Select());
    }

    public void Hide()
    {
        transform.DOScaleY(0, 0.1f);
    }

    public void ContinueButton()
    {
        Hide();
    }

    public void InstructionsButtons()
    {
        
    }

    public void MenuButton()
    {
        ScenesManager.Instance.LoadScene(0);
    }
}

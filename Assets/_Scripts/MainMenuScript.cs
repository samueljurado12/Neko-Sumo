using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField]
    Button[] buttons;

    private void Start()
    {
        if (Input.GetJoystickNames().Length > 0);
            buttons[0].Select();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            buttons[0].Select();
    }
    
    public void StartGameButton()
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

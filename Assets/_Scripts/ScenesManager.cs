using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance { private set; get; }

    [SerializeField]
    Image fadeGraphic;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
            //returnButton.Select();
            StartCoroutine(GetControllers());
        }

    }

    public void LoadScene(int index)
    {
        LoadScene(index, Color.white);
    }

    public void LoadScene(int index, Color color)
    {
        color.a = 0;
        fadeGraphic.color = color;
        fadeGraphic.DOFade(1, 0.25f).OnComplete(() => SceneManager.LoadScene(index));
    }

    

    private void Update()
    {
        
            
    }

    public string[] joysticks;
    IEnumerator GetControllers()
    {
        while(true)
        {
            joysticks = Input.GetJoystickNames();
            if (IsJoystickConnected())
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            yield return new WaitForSeconds(2);
        }
        
    }

    public bool IsJoystickConnected()
    {
        return joysticks.Length > 0 && !string.IsNullOrEmpty(joysticks[0]);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        fadeGraphic.DOFade(0, 0.5f);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}

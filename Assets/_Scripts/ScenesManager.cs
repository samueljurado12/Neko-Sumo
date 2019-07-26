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
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    public void LoadScene(int index)
    {
        fadeGraphic.DOFade(1, 0.5f).OnComplete(() => SceneManager.LoadScene(index));
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

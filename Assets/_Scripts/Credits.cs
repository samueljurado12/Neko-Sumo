using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Button returnButton;

    public void ReturnButton()
    {
        ScenesManager.Instance.LoadScene(0, Color.black);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            returnButton.Select();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour, ISelectHandler
{
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.botonPulsado);

    }

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.botonSeleccionado);
    }

}

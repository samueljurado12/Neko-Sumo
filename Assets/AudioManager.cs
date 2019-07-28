using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { private set; get; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField]
    AudioSource sfx;
    public AudioClip botonSeleccionado, botonPulsado, victory;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
}

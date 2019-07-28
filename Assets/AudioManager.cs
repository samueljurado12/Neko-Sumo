using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { private set; get; }
    public AudioSource player1AudioSource;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField]
    AudioSource sfx;
    public AudioClip botonSeleccionado, botonPulsado, victory, dash, distantAttack1, distantAttack2, jump, waterFall1, waterFall2, meleeAttack, meow1, meow2, meowStart, splash;

    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }

    public void MeleeAttack(AudioSource audioSource) {
        audioSource.clip = meleeAttack;
        audioSource.Play();
    }

    public void Dash(AudioSource audioSource) {
        audioSource.clip = dash;
        audioSource.Play();
    }

    public void DistantAttack(AudioSource audioSource) {
        int n = Random.Range(0, 2);
        if(n == 0) {
            audioSource.clip = distantAttack1;
            audioSource.Play();
        } else {
            audioSource.clip = distantAttack2;
            audioSource.Play();
        }
    }

    public void Jump(AudioSource audioSource) {
        audioSource.clip = jump;
        audioSource.Play();
    }

    public void WaterFall(AudioSource audioSource) {
        int n = Random.Range(0, 2);
        if (n == 0) {
            audioSource.clip = waterFall1;
            audioSource.Play();
        } else {
            audioSource.clip = waterFall2;
            audioSource.Play();
        }
    }

    public void Meow(AudioSource audioSource) {
        int n = Random.Range(0, 2);
        if (n == 0) {
            audioSource.clip = meow1;
            audioSource.Play();
        } else {
            audioSource.clip = meow2;
            audioSource.Play();
        }
    }

    public void Splash() {
        sfx.clip = splash;
        sfx.Play();
    }

    private void Start() {
        if (SceneManager.GetActiveScene().name == "Juego") {
            player1AudioSource.clip = meowStart;
            player1AudioSource.Play();
        }
    }
}

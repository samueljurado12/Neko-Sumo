using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        MonoBehaviour cm;
        if (cm = other.GetComponent<CharacterMovement>())
        {
            Debug.Log("Jugador " + ((CharacterMovement)cm).PlayerNumber + " ha caído");
        }else if (other.GetComponent<Furball>())
        {
            Destroy(other.gameObject);
        }
    }
}

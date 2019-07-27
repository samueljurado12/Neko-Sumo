using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreen : MonoBehaviour
{
    bool victory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && victory == false)
        {
            int player = other.GetComponent<CharacterMovement>().PlayerNumber;
            if (player == 1)
                WinScreen.Instance.Show(2);
            else if (player == 2)
                WinScreen.Instance.Show(1);
            victory = true;

        }else if (other.GetComponent<Furball>())
        {
            Destroy(other.gameObject);
        }
    }
}

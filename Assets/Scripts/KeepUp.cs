using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepUp : MonoBehaviour
{
    CharacterMovement character;
    Rigidbody2D rb;

    private void Awake()
    {
        character = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.up = PlatformManager.Instance.transform.up;
        if (character.GetGrounded())
            rb.drag = 5;
        else
            rb.drag = 0.2f;

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        rb.drag = 1;
    }

    private void OnCollisionExit(Collision collision)
    {
        rb.drag = 0.2f;
    }
}

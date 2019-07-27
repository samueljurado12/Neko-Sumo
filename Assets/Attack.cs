using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator animator;
    CharacterMovement cm;
    Rigidbody2D rb;
    [SerializeField]
    Collider2D col;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        cm = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Melee" + cm.PlayerNumber))
        {
            Debug.Log("Melee");
            animator.SetTrigger("Attack");
            col.enabled = true;
        }else
        {
            col.enabled = false;
        }

        if (Input.GetButtonDown("Dash" + cm.PlayerNumber))
        {
            rb.AddForce(transform.right * rb.mass * 1000);
            Debug.Log("Dash");
            animator.SetTrigger("Dash");
        }
    }
}

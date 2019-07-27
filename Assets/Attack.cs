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
    [SerializeField]
    float dashPower = 1000;

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
            animator.SetTrigger("Attack");
            col.enabled = true;
        }else
        {
            col.enabled = false;
        }

        if (Input.GetButtonDown("Dash" + cm.PlayerNumber))
        {
            rb.AddForce(transform.right * transform.localScale.x * rb.mass * dashPower);
            animator.SetTrigger("Dash");
        }
    }
}

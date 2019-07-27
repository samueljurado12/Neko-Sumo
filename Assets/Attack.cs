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
    public float cooldownDash = 1, dashPower = 500;
    float timeRemainingDash = 0;

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

        if (timeRemainingDash > 0)
            timeRemainingDash -= Time.deltaTime;

        if (Input.GetButtonDown("Dash" + cm.PlayerNumber) && cm.GetGrounded() && timeRemainingDash <= 0)
        {
            rb.AddForce(transform.right * transform.localScale.x * rb.mass * dashPower);
            animator.SetTrigger("Dash");
            timeRemainingDash = cooldownDash;
        }
    }
}

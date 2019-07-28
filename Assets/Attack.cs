using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator animator;
    CharacterMovement cm;
    Rigidbody2D rb;
    [SerializeField]
    float cooldownDash = 1, dashPower = 500;
    float timeRemainingDash = 0;
    [SerializeField]
    float meleePower = 500;

    AudioSource audioSource;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        cm = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Melee" + cm.PlayerNumber))
        {
            animator.SetTrigger("Attack");
            AudioManager.Instance.MeleeAttack(audioSource);

            Vector3 origin = transform.position + transform.right * transform.localScale.x;
            Vector3 dir = Vector3.right * transform.localScale.x;
            Debug.DrawRay(origin, dir);
            RaycastHit2D hit = Physics2D.Raycast(origin, dir, 0.5f);

            // If it hits something...
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log(hit.collider.name);
                Vector3 force = dir * meleePower;
                hit.collider.GetComponent<Rigidbody2D>().AddForce(force);
                hit.collider.GetComponentInChildren<Animator>().SetTrigger("Damage");
            }

        }

        if (timeRemainingDash > 0)
            timeRemainingDash -= Time.deltaTime;

        if (Input.GetButtonDown("Dash" + cm.PlayerNumber) && cm.GetGrounded() && timeRemainingDash <= 0)
        {
            AudioManager.Instance.Dash(audioSource);
            rb.AddForce(transform.right * transform.localScale.x * rb.mass * dashPower);
            animator.SetTrigger("Dash");
            timeRemainingDash = cooldownDash;

        }
    }
}

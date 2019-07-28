using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Obstacle
{

    [Header("Fish Attributes")]

    [SerializeField] private float rotationOffset;
    [SerializeField] private Transform followObject;
    [SerializeField] private Transform pivot;

    private SpriteRenderer sprite;

    protected override void Behaviour()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.sortingOrder = -1;
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(90 - rotationOffset, 90 + rotationOffset));
        movesRight = transform.localEulerAngles.z < 90;
        transform.localScale = movesRight ? new Vector3(1, -1, 1) : Vector3.one;
        rb.velocity = (followObject.position - transform.position) * speed;
        Destroy(gameObject, 8);
    }

    private void FixedUpdate()
    {
        pivot.localEulerAngles = -transform.localEulerAngles;
        Vector2 acceleration = Vector2.down * Physics2D.gravity * Time.deltaTime;
        followObject.localPosition = Vector3.Normalize(rb.velocity);
        float rotationIndex = followObject.position.z;

        if (rb.velocity.y < 0)
        {
            sprite.sortingOrder = 9;
        }

        var newRotation = Quaternion.LookRotation(followObject.position - transform.position, Vector3.forward);
        newRotation.x = 0;
        newRotation.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime);

        rb.velocity -= acceleration;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 9 && rb.velocity.y < 0.5)
        {
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(
                Vector2.right * transform.localScale.y * -1 * hitForce * speed
                    , ForceMode2D.Impulse);
            GetComponent<Collider2D>().enabled = false;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bird : Obstacle
{
    protected override void Behaviour()
    {
        var _direction = movesRight ? Vector3.right : Vector3.left;
        rb.velocity = _direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 9)
        {
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(rb.velocity * hitForce, ForceMode2D.Impulse);
            GetComponent<Collider2D>().enabled = false;
        }

    }
}

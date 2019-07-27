using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furball : MonoBehaviour
{
    public new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            var player = GetComponent<Rigidbody2D>();
            //player.AddForce()
        }
    }
}

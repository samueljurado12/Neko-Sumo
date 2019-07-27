using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollider : MonoBehaviour
{
    [SerializeField]
    float force = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float dir = transform.parent.localScale.x;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * dir * force);
        }
    }
}

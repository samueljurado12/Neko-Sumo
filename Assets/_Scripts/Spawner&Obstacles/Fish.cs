using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Obstacle
{

    [Header("Fish Attributes")]

    [SerializeField] private float rotationOffset;
    [SerializeField] private Transform followObject;

    protected override void Behaviour()
    {
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(90 - rotationOffset, 90 + rotationOffset));
        rb.velocity =  (followObject.position - transform.position) * speed;
    }

    private void FixedUpdate()
    {
        rb.velocity -= Vector2.down * Physics2D.gravity * Time.deltaTime;
    }
}

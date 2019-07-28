using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Obstacle
{

    [Header("Fish Attributes")]

    [SerializeField] private float rotationOffset;
    [SerializeField] private Transform followObject;
    [SerializeField] private Transform pivot;

    private Vector3 objectiveRotation;

    protected override void Behaviour()
    {
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(90 - rotationOffset, 90 + rotationOffset));
        objectiveRotation = new Vector3(0, 0, -transform.localEulerAngles.z);
        movesRight = transform.localEulerAngles.z < 90;
        transform.localScale = movesRight ? new Vector3(1, -1, 1) : Vector3.one;
        rb.velocity = (followObject.position - transform.position) * speed;
    }

    private void FixedUpdate()
    {
        pivot.localEulerAngles = -transform.localEulerAngles;
        Vector2 acceleration = Vector2.down * Physics2D.gravity * Time.deltaTime;
        followObject.localPosition = Vector3.Normalize(rb.velocity);
        float rotationIndex = followObject.position.z;

        //Vector3 diff = followObject.localPosition - transform.position;
        //diff.Normalize();

        //float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        var newRotation = Quaternion.LookRotation(followObject.position- transform.position, Vector3.forward);
        newRotation.x = 0;
        newRotation.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime);

        //transform.LookAt(followObject);
        rb.velocity -= acceleration;
    }
}

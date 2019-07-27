using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStabilizer : MonoBehaviour
{
    public PID pid;
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.AddTorque(pid.Update(0, transform.localRotation.z, Time.deltaTime));
    }
}

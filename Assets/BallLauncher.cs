using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{

    [SerializeField]
    float launchForce, cooldown = 5;
    float timeRemaining;

    void Start()
    {
        
    }

    void Update()
    {
        if (timeRemaining > 0)
            timeRemaining -= Time.deltaTime;

        if (Input.GetButtonDown("Furball" + GetComponent<CharacterMovement>().PlayerNumber) && timeRemaining <= 0)
        {
            ThrowHairBall();
            timeRemaining = cooldown;
        }
    }

    [SerializeField]
    Object ballPrefab;
    public void ThrowHairBall()
    {
        Furball ball = ((GameObject)Instantiate(ballPrefab)).GetComponent<Furball>();
        Vector3 force = Vector2.right * transform.localScale.x * launchForce;
        ball.rigidbody.AddForce(force, ForceMode2D.Impulse);
        ball.transform.position = transform.position + Vector3.up;
    }
}

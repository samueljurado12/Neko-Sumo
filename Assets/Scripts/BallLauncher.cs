using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{

    [SerializeField]
    float launchForce, cooldown = 5;
    float timeRemaining;
    Animator anim;
    [SerializeField]
    GameObject ballHolder;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (timeRemaining > 0)
            timeRemaining -= Time.deltaTime;

        if (Input.GetButtonDown("Furball" + GetComponentInParent<CharacterMovement>().PlayerNumber) && timeRemaining <= 0)
        {
            anim.SetTrigger("Spit");
            timeRemaining = cooldown;
        }
    }

    [SerializeField]
    Object ballPrefab;
    public void ThrowHairBall()
    {
        Furball ball = ((GameObject)Instantiate(ballPrefab)).GetComponent<Furball>();
        ball.transform.parent = ballHolder.transform;
        ball.transform.localPosition = Vector3.zero;
        Vector3 force = Vector2.right * transform.parent.localScale.x * launchForce;
        ball.rigidbody.AddForce(force, ForceMode2D.Impulse);
        ball.transform.parent = null;
    }

    public void Dash()
    {
        transform.parent.GetComponent<Attack>().Dash();
    }

}

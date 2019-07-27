using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformStabilizer : MonoBehaviour
{
    new Rigidbody2D rigidbody;

    [SerializeField]
    CharacterMovement[] players;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (players == null || players.Length == 0)
            players = FindObjectsOfType<CharacterMovement>();
    }

    void FixedUpdate()
    {
    }

    [SerializeField]
    float returnTime = 3;
    Tweener tweener;

    private void Update()
    {
        if (!players[0].GetGrounded() && !players[1].GetGrounded())
        {
            tweener = rigidbody.DORotate(0, returnTime);
        }
        else
        {
            tweener.Kill();
        }
    }
}

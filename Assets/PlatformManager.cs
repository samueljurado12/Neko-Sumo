using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance { private set; get; }

    private void Awake()
    {
        Instance = this;
    }

    new Rigidbody2D rigidbody;

    [SerializeField]
    List<CharacterMovement> players;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (players == null || players.Count == 0)
            players = FindObjectsOfType<CharacterMovement>().ToList();
    }

    void FixedUpdate()
    {
    }

    private void Update()
    {
        
        if (players.FindAll(o => !o.GetGrounded()).Count == 1)
        {
            Debug.Log("Un jugador ha caído");
        }
        else
        {

        }
        /*
        if (!players[0].GetGrounded() && !players[1].GetGrounded())
        {
            tweener = rigidbody.DORotate(0, returnTime);
        }
        else
        {
            tweener.Kill();
        }*/

    }
}

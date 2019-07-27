using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class Obstacle : MonoBehaviour
{

    [SerializeField]
    [Range(1, 6)]
    protected float speed = 3;

    [SerializeField]
    [Range(1, 3)]
    protected float hitForce = 3;
    [SerializeField] protected bool movesRight = true;
    public bool MovesRight { get { return movesRight; } set { movesRight = value; } }

    protected Rigidbody2D rb;
    protected Collider2D col;
    protected Vector3 _direction;
    private Vector3 facingDirection;

    // Start is called before the first frame update
    void Awake()
    {
        SetPhysicsComponents();
        facingDirection = movesRight ? Vector3.right : Vector3.left;
        transform.localScale = new Vector3(facingDirection.x * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    protected void SetPhysicsComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        col.isTrigger = true;
    }

    private void Start()
    {
        Behaviour();
    }

    protected abstract void Behaviour();

}

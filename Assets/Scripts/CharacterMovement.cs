/*
 * Author: Samuel Jurado Quintana
 * Co-Authors: Enrique Botella Garcés, Jesús Garcés Villarrubia
 * Date: 26/07/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityChan;
[SelectionBase]
public class CharacterMovement : MonoBehaviour
{

    #region Properties and Editor vars
    [SerializeField]
    [Range(1, 2)]
    private int playerNumber;

    public int PlayerNumber
    {
        get { return playerNumber; }
    }

    [SerializeField]
    private LayerMask platformLayer;

    [SerializeField]
    private GameObject tail, belt;

    [Range(1, 10)]
    [SerializeField]
    private float speed = 1, fallMultiplier = 2.5f, lowJumpMultiplier = 2;

    [Range(0, 2)]
    [SerializeField]
    private float raycastDistance = 1;

    [Range(1, 100)]
    [SerializeField]
    private float forceMultiplier = 1, jumpForce = 5;
    #endregion

    #region Input and Unity components
    private float horizontalAxis;
    private Rigidbody2D rb;
    #endregion

    #region Private variables
    private Vector2 _horizontalMovement, _raycastOriginLeft, _raycastOriginRight;
    private bool jumpRequest;
    private Vector3 facingLeft, facingRight;
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        belt.GetComponent<Anima2D.SpriteMeshInstance>().color = playerNumber == 1 ? new Color(204, 0, 0) : new Color(0, 116, 204);
        jumpRequest = false;
        horizontalAxis = 0;
        _horizontalMovement = new Vector2();
        _raycastOriginLeft = new Vector2(transform.position.x - 0.25f, transform.position.y - 0.5f);
        _raycastOriginRight = new Vector2(transform.position.x + 0.25f, transform.position.y - 0.5f);
        rb = gameObject.GetComponent<Rigidbody2D>();
        facingRight = Vector3.one;
        facingLeft = new Vector3(-1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
        horizontalAxis = Input.GetAxis("Horizontal" + playerNumber);

        jumpRequest = Input.GetButtonDown("Jump" + playerNumber);

    }

    private void FixedUpdate()
    {
        SetFacing();
        Jump();
        HorizontalMovement();
        if (!GetGrounded())
        {
            Fall();
        }
    }
    #endregion

    #region Movement methods

    private void HorizontalMovement()
    {
        _horizontalMovement.x = speed * horizontalAxis;
        if (rb.velocity.x < speed)
            rb.AddForce(_horizontalMovement * forceMultiplier);
    }

    private void SetFacing()
    {
        if (horizontalAxis != 0)
        {
            if (rb.velocity.x < 0)
            {
                transform.localScale = facingLeft;
            }
            else if (rb.velocity.x > 0)
            {
                transform.localScale = facingRight;
            }

        }
        foreach (SpringBone t in tail.GetComponentsInChildren<SpringBone>())
        {
            t.springForce.x = -0.001f * transform.localScale.x;
            if (t.springForce.x * 10 * t.stiffnessForce > 0)
            {
                t.stiffnessForce *= -1;
            }
        }
    }

    private void Jump()
    {
        if (jumpRequest && GetGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpRequest = false;
        }
    }

    private void Fall()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime * (fallMultiplier - 1);
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump" + playerNumber))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * Time.deltaTime * (lowJumpMultiplier - 1);
        }

    }
    #endregion

    #region Auxiliar Methods

    private void Raycast()
    {
        _raycastOriginLeft.x = transform.position.x - 0.25f;
        _raycastOriginLeft.y = transform.position.y - 0.5f;
        _raycastOriginRight.x = transform.position.x + 0.25f;
        _raycastOriginRight.y = transform.position.y - 0.5f;
        Debug.DrawRay(_raycastOriginLeft, Vector2.down * raycastDistance, Color.yellow);
        Debug.DrawRay(_raycastOriginRight, Vector2.down * raycastDistance, Color.yellow);
    }

    public bool GetGrounded()
    {
        return Physics2D.Raycast(_raycastOriginLeft, Vector2.down, raycastDistance, platformLayer) ||
            Physics2D.Raycast(_raycastOriginRight, Vector2.down, raycastDistance, platformLayer);
    }
    #endregion

}

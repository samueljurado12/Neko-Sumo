/*
 * Author: Samuel Jurado Quintana
 * Co-Authors: Enrique Botella Garcés
 * Date: 26/07/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    #region Properties and Editor vars
    [Range(1, 2)]
    [SerializeField]
    private int playerNumber = 1;

    [SerializeField]
    private LayerMask platformLayer;

    [Range(1, 10)]
    [SerializeField]
    private float speed = 1, fallMultiplier = 2.5f, lowJumpMultiplier = 2;

    [Range(0,1)]
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
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        horizontalAxis = 0;
        _horizontalMovement = new Vector2();
        _raycastOriginLeft = new Vector2(transform.position.x - 0.25f, transform.position.y - 0.5f);
        _raycastOriginRight = new Vector2(transform.position.x + 0.25f, transform.position.y - 0.5f);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
        horizontalAxis = Input.GetAxis("Horizontal" + playerNumber);
        Debug.Log(GetGrounded());
    }

    private void FixedUpdate()
    {
        Jump();
        HorizontalMovement();
    }
    #endregion

    #region Movement methods

    private void HorizontalMovement()
    {
        _horizontalMovement.x = speed * horizontalAxis;
        if (rb.velocity.x < speed)
            rb.AddForce(_horizontalMovement * forceMultiplier);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump" + playerNumber) && GetGrounded())
        {
            //rb.AddForce(Vector2.up * forceMultiplier, ForceMode2D.Impulse);
            rb.velocity = Vector2.up * jumpForce;
        }
        if(rb.velocity.y < 0 && !GetGrounded())
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime * (fallMultiplier - 1);
        }
        else if(rb.velocity.y < 0 && !GetGrounded() && !Input.GetButton("Jump"))
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

    private bool GetGrounded()
    {
        return Physics2D.Raycast(_raycastOriginLeft, Vector2.down, raycastDistance, platformLayer) ||
            Physics2D.Raycast(_raycastOriginRight, Vector2.down, raycastDistance, platformLayer);
    }
    #endregion

}

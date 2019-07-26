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
    private LayerMask layerMask;

    [Range(1, 10)]
    [SerializeField]
    private float speed = 1;

    [Range(0,1)]
    [SerializeField]
    private float raycastDistance = 1;

    [Range(1, 100)]
    [SerializeField]
    private float forceMultiplier = 1;
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
        Debug.Log(GetGrounded());
        if (rb.velocity.x < speed)
            rb.AddForce(_horizontalMovement * forceMultiplier);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump" + playerNumber) && GetGrounded())
        {
            rb.AddForce(Vector2.up * forceMultiplier * 2, ForceMode2D.Impulse);
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
        return Physics2D.Raycast(_raycastOriginLeft, Vector2.down, raycastDistance, layerMask) ||
            Physics2D.Raycast(_raycastOriginRight, Vector2.down, raycastDistance, layerMask);
    }
    #endregion

}

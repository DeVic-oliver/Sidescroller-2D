using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    #region Player Actions variables
    private bool isGrounded = false;
    private bool isJumping = false;
    private bool isFalling = false;
    private bool isMoving = false;
    private bool isLanding = false;
    #endregion
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        CheckIfPlayerIsMoving();
        CheckIfPlayerIsFalling();
        CheckIfPlayerIsJumping();
        CheckIfPlayerIsOnGround();
        CheckIfPlayerIsLanding();
    }
    /// <summary>
    /// Checks if player is moving based on rigidbody velocity X
    /// </summary>
    /// <returns>true | false</returns>
    public bool CheckIfPlayerIsMoving()
    {
        float playerVelocity = Mathf.RoundToInt(_playerMovement.GetPlayerRigidbodyHorizontalVelocity());
        if (playerVelocity != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        return isMoving;
    }
    /// <summary>
    /// Checks if player is jumping based on rigidbody velocity Y
    /// </summary>
    /// <returns>true | false</returns>
    public bool CheckIfPlayerIsJumping()
    {
        if(_playerMovement.GetPlayerRigidbodyVerticalVelocity() > 0f && !isGrounded)
        {
            isJumping = true;
            isFalling = false;
        }
        else
        {
            isJumping = false;
        }
        return isJumping;
    }
    /// <summary>
    /// Checks if player is falling based on rigidbody velocity Y
    /// </summary>
    /// <returns>true | false</returns>
    public bool CheckIfPlayerIsFalling()
    {
        if (_playerMovement.GetPlayerRigidbodyVerticalVelocity() < 0f && !isGrounded)
        {
            isFalling = true;
            isJumping = false;
        }
        else
        {
            isFalling = false;
        }
        return isFalling;
    }
    /// <summary>
    /// Checks if player is touching the ground
    /// </summary>
    /// <returns>true | false</returns>
    public bool CheckIfPlayerIsOnGround()
    {
        return isGrounded;
    }
    /// <summary>
    /// Check if player start touch the ground. When player stays touching the ground returns false;
    /// </summary>
    /// <returns>true | false</returns>
    public bool CheckIfPlayerIsLanding()
    {
        return isLanding;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isLanding = true;
            isJumping = false;
            isFalling = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
            isLanding = false;
        }
    }
}

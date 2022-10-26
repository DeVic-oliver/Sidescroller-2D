using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData PlayerData;
    private Rigidbody2D _rigidbody;
    private float moveSpeed;
    #region Player Movement variables
    private bool isGrounded = false;
    private bool isJumping = false;
    private bool isFalling = false;
    private bool isMoving = false;
    private bool hasLanded = false;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        SetDefaultMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerIsMoving();
        CheckJumpInput();
        ReducePlayerVelocityByFrame();
        if(GetPlayerRigidbodyVerticalVelocity() < 0)
        {
            SetIsFalling(true);
        }
    }
    private void CheckIfPlayerIsMoving()
    {
        float playerVelocity = Mathf.RoundToInt(GetPlayerRigidbodyHorizontalVelocity());
        if (playerVelocity != 0)
        {
            isMoving = true;
        }
        else
        { 
            isMoving = false; 
        }
    }
    private void CheckJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            _rigidbody.velocity = Vector2.up * PlayerData.JumpForce;
            SetIsJumping(true);
        }
    }
    private void SetIsJumping(bool value)
    {
        isJumping = value;
    }
   private void SetIsFalling(bool value)
    {
        isFalling = value;
    }
    
    private void ReducePlayerVelocityByFrame()
    {
        if(_rigidbody.velocity.x > 0)
        {
            _rigidbody.velocity -= new Vector2(.1f, 0);
        }
        else if(_rigidbody.velocity.x < 0)
        {
            _rigidbody.velocity -= new Vector2(-.1f, 0);
        }
    }
    private void FixedUpdate()
    {
        CheckMovementInput();
    }
    private void CheckMovementInput()
    {
        if(Input.GetKey(KeyCode.A))
        {
            MovePlayerToLeft();
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }else if (Input.GetKey(KeyCode.D))
        {
            MovePlayerToRight();
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        CheckRunInput();
    }
    private void MovePlayerToLeft() 
    {
        _rigidbody.velocity = new Vector2(-moveSpeed, _rigidbody.velocity.y);
    }
    private void MovePlayerToRight()
    {
        _rigidbody.velocity = new Vector2(moveSpeed, _rigidbody.velocity.y);
    }
    private void CheckRunInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            SetRunSpeed();
        }
        else
        {
            SetDefaultMoveSpeed();
        }
    }
    private void SetRunSpeed()
    {
        moveSpeed = PlayerData.RunSpeed;
    }
    private void SetDefaultMoveSpeed()
    {
        moveSpeed = PlayerData.MoveSpeed;
    }
    /// <summary>
    /// Checks if player is moving based on rigidbody velocity X
    /// </summary>
    /// <returns>true | false</returns>
    public bool CheckIfIsPlayerMoving()
    {
        return isMoving;
    }
    /// <summary>
    /// Checks if player has jumped based on rigidbody velocity Y
    /// </summary>
    /// <returns>true | false</returns>
    public bool CheckIfPlayerIsJumping()
    {
        return isJumping;
    }
    /// <summary>
    /// Checks if player is falling based on rigidbody velocity y
    /// </summary>
    /// <returns>true | false</returns>
    public bool CheckIfIsPlayerFalling()
    {
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
    /// Checks if player is touching the ground
    /// </summary>
    /// <returns>true | false</returns>
    public bool CheckIfPlayerLands()
    {
        return hasLanded;
    }
    /// <summary>
    /// Returns the player rigidbody velocity in X axis;
    /// </summary>
    /// <returns>a float number</returns>
    public float GetPlayerRigidbodyHorizontalVelocity()
    {
        return _rigidbody.velocity.x;
    }
    /// <summary>
    /// Returns the player rigidbody velocity in Y axis;
    /// </summary>
    /// <returns>a float number</returns>
    public float GetPlayerRigidbodyVerticalVelocity()
    {
        return _rigidbody.velocity.y;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            SetHasLanded(true);
            SetIsJumping(false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            SetHasLanded(false);
        }
    }
    private void SetHasLanded(bool value)
    {
        hasLanded = value;
    }
}

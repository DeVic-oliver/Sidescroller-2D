using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData PlayerData;
    private Rigidbody2D _rigidbody;
    private float moveSpeed;
    private PlayerAnimationManager _animationManager;
    #region Player JumpStates variables
    private bool isGrounded = false;
    private bool hasJumped = false;
    private bool isFalling = false;
    private bool isMoving = false;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animationManager = GetComponent<PlayerAnimationManager>();
        SetDefaultMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerIsMoving();
        WatchJumpAnimation();
        CheckJumpInput();
        ReducePlayerVelocityByFrame();
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
    private void LateUpdate()
    {
    }
    private void WatchJumpAnimation()
    {
        if (_rigidbody.velocity.y > 0 && isGrounded)
        {
            _animationManager.TriggerJumpAnimation();
        }
        else if (_rigidbody.velocity.y < 0 && !isFalling)
        {
            SetIsFallingToTrue();
            _animationManager.TriggerFallAnimation();
        }
    }
    private void SetJumpedToFalse()
    {
        hasJumped = false;
    }
    private void SetJumpedToTrue()
    {
        hasJumped = true;
    }
    private void SetIsFallingToFalse()
    {
        isFalling = false;
    }
    private void SetIsFallingToTrue()
    {
        isFalling = true;
    }
    private void CheckJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasJumped)
        {
            _rigidbody.velocity = Vector2.up * PlayerData.JumpForce;
            SetJumpedToTrue();
        }
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
   /// Check if player rigidbody velocity x is different than zero
   /// </summary>
   /// <returns>true | false</returns>
    public bool IsPlayerMoving()
    {
        return isMoving;
    }

    /// <summary>
    /// Returns the player rigidbody velocity in X axis;
    /// </summary>
    /// <returns>a float number</returns>
    public float GetPlayerRigidbodyHorizontalVelocity()
    {
        return _rigidbody.velocity.x;
    }
}

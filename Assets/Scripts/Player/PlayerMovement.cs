using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData PlayerData;
    private Rigidbody2D _rigidbody;
    private float moveSpeed;
    private PlayerAnimationManager _animationManager;
    private bool isGrounded;
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
        CheckJumpInput();
        ReducePlayerVelocityByFrame();
    }
    private void LateUpdate()
    {
        WatchRunAnimation();
        WatchJumpAnimation();
    }
    private void WatchJumpAnimation()
    {
        if (_rigidbody.velocity.y > 0)
        {
            _animationManager.TriggerJumpAnimation();
            _animationManager.EnableAnimation("IsGrounded", false);
        }
        else if (_rigidbody.velocity.y < 0)
        {
            _animationManager.TriggerFallAnimation();
            _animationManager.EnableAnimation("IsGrounded", false);
        }
        else if (_rigidbody.velocity.y == 0)
        {
            _animationManager.TriggerLandAnimation();
            _animationManager.EnableAnimation("IsGrounded", true);
        }
    }
    private void CheckJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = Vector2.up * PlayerData.JumpForce;
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
    private void WatchRunAnimation()
    {
        float playerVelocity = Mathf.RoundToInt(_rigidbody.velocity.x);

        if (playerVelocity != 0)
        {
            _animationManager.EnableRunAnimation();
        }
        else
        {
            _animationManager.DisableRunAnimation();
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
   
}

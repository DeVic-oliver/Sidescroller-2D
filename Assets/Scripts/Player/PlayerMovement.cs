using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData PlayerData;
    private Rigidbody2D _rigidbody;
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        SetDefaultMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckJumpInput();
    private void CheckJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = Vector2.up * PlayerData.JumpForce;
        }
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
        }else if (Input.GetKey(KeyCode.D))
        {
            MovePlayerToRight();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Core.Interfaces;
public class PlayerMovement : IMoveable
{
    private Rigidbody2D _playerRigidbody;
    private PlayerData _playerData;
    private float moveSpeed;
    private float jumpForce;
    private float runSpeed;

    public PlayerMovement(PlayerData playerData, Rigidbody2D rigidbody)
    {
        _playerData = playerData;
        moveSpeed = playerData.MoveSpeed;
        jumpForce = playerData.JumpForce;
        runSpeed = playerData.RunSpeed;
        _playerRigidbody = rigidbody;
    }
    public void Move(bool isAlive)
    {
        if (isAlive)
        {
            float inputAxisValue = Input.GetAxis("Horizontal");
            _playerRigidbody.velocity = new Vector2(inputAxisValue * moveSpeed, _playerRigidbody.velocity.y);
            RotatePlayer(inputAxisValue);
            CheckJumpInput();
            CheckRunInput();
        }
    }
    private void RotatePlayer(float axisValue)
    {
        if(axisValue < 0)
        {
            _playerRigidbody.transform.eulerAngles = Vector3.up * 180f;
        }
        else if(axisValue > 0)
        {
            _playerRigidbody.transform.eulerAngles = Vector3.up * 0;
        }
    }
    private void CheckJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerRigidbody.velocity = Vector2.up * jumpForce;
        }
    }
    private void CheckRunInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            SetRunSpeed();
        }
        else
        {
            SetDefaultSpeed();
        }
    }
    private void SetRunSpeed()
    {
        moveSpeed = runSpeed;
    }
    private void SetDefaultSpeed()
    {
        moveSpeed = _playerData.MoveSpeed;
    }
}

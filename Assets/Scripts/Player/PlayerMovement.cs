using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Core.Interfaces;
public class PlayerMovement : IMoveable
{
    private PlayerData _playerData;
    private Rigidbody2D _rigidbody;
    private float moveSpeed;
    private float jumpForce;
    private float runSpeed;
    public PlayerMovement(PlayerData playerData, Rigidbody2D rigidbody)
    {
        _playerData = playerData;
        moveSpeed = playerData.MoveSpeed;
        jumpForce = playerData.JumpForce;
        runSpeed = playerData.RunSpeed;
        _rigidbody = rigidbody;
    }
    public void Move(bool isAlive)
    {
        if (isAlive)
        {
            float inputAxisValue = Input.GetAxis("Horizontal");
            _rigidbody.velocity = new Vector2(inputAxisValue * moveSpeed, _rigidbody.velocity.y);
            RotatePlayer(inputAxisValue);
            CheckJumpInput();
            CheckRunInput();
        }
    }
    private void RotatePlayer(float axisValue)
    {
        if(axisValue < 0)
        {
            _rigidbody.transform.eulerAngles = Vector3.up * 180f;
        }
        else if(axisValue > 0)
        {
            _rigidbody.transform.eulerAngles = Vector3.up * 0;
        }
    }
    private void CheckJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = Vector2.up * jumpForce;
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
}

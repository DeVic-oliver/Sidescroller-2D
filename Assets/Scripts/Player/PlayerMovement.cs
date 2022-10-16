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
        _rigidbody.MovePosition(_rigidbody.position + Vector2.left * moveSpeed );
    }
    private void MovePlayerToRight()
    {
        _rigidbody.MovePosition(_rigidbody.position + Vector2.right * moveSpeed);
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
        moveSpeed = PlayerData.RunSpeed * Time.deltaTime;
    }
    private void SetDefaultMoveSpeed()
    {
        moveSpeed = PlayerData.MoveSpeed * Time.deltaTime;
    }
}

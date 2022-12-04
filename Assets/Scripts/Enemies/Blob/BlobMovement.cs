using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Core.Interfaces;
public class BlobMovement : IMoveable
{
    private enum MovementDirection
    {
        Left,
        Right
    }
    private int _minMoveRangeLimit;
    private int _maxMoveRangeLimit;
    private float _moveSpeed;
    private Transform _transform;
    private int localMinRangeLimit;
    private int  localMaxRangeLimit;
    private Vector3 movementVector = Vector3.left;
    private MovementDirection _movementDirection;

    public BlobMovement(float moveSpeed, int minMoveRangeLimit, int maxMoveRangeLimit, Transform blobTransform)
    {
        _moveSpeed = moveSpeed;
        _minMoveRangeLimit = minMoveRangeLimit;
        _maxMoveRangeLimit = maxMoveRangeLimit;
        _transform = blobTransform;
        TreatXRangeUnits(_minMoveRangeLimit);
        TreatXRangeUnits(_maxMoveRangeLimit);
        localMinRangeLimit = Mathf.RoundToInt(_transform.localPosition.x) - _minMoveRangeLimit;
        localMaxRangeLimit = Mathf.RoundToInt(_transform.localPosition.x) + _maxMoveRangeLimit;
    }
   
    private void TreatXRangeUnits(float value)
    {
        if (value < 0)
        {
            value *= -1;
        }
    }
    public void Move(bool isAlive)
    {
        if (isAlive)
        {
            CheckMoveDirection();
            _transform.position += movementVector * _moveSpeed * Time.deltaTime;
        }
    }
    private void CheckMoveDirection()
    {
        int positionRounded = Mathf.RoundToInt(_transform.localPosition.x);
        if (_movementDirection == MovementDirection.Left)
        {
            CheckIfReachedAtMinimumRangeLimit(positionRounded);
        }
        else
        {
            CheckIfReachedAtMaximumRangeLimit(positionRounded);
        }
    }
    private void CheckIfReachedAtMinimumRangeLimit(int positionRounded)
    {
        if (positionRounded <= localMinRangeLimit)
        {
            RotateBlob(180);
            ChangeMovementDirection(MovementDirection.Right);
            ChangeMovement(Vector3.right);
        }
    }
    private void CheckIfReachedAtMaximumRangeLimit(int positionRounded)
    {
        if (positionRounded >= localMaxRangeLimit)
        {
            RotateBlob(0);
            ChangeMovementDirection(MovementDirection.Left);
            ChangeMovement(Vector3.left);
        }
    }
    private void ChangeMovement(Vector3 newMovementVector)
    {
        movementVector = newMovementVector;
    }
    private void ChangeMovementDirection(MovementDirection movementDirection)
    {
        _movementDirection = movementDirection;
    }
    private void RotateBlob(float value)
    {
        Quaternion newRotation = Quaternion.Euler(0, value, 0);
        _transform.rotation = newRotation;
    }
}

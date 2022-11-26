using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BlobMovement : MonoBehaviour
{
    private enum MovementDirection
    {
        Left,
        Right
    }
    [Header("Movement Settings")]
    [SerializeField] private int MinRangeLimit;
    [SerializeField] private int MaxRangeLimit;
    [SerializeField] private float moveSpeed;
    private int localMinRangeLimit;
    private int  localMaxRangeLimit;
    private Vector3 movementVector = Vector3.left;
    private MovementDirection _movementDirection;

    void Start()
    {
        TreatXRangeUnits(MinRangeLimit);
        TreatXRangeUnits(MaxRangeLimit);
        localMinRangeLimit = Mathf.RoundToInt(transform.localPosition.x) - MinRangeLimit;
        localMaxRangeLimit = Mathf.RoundToInt(transform.localPosition.x) + MaxRangeLimit;
    }
    private void TreatXRangeUnits(float value)
    {
        if (value < 0)
        {
            value *= -1;
        }
    }
    void Update()
    {
        MoveBlob();
    }
    private void MoveBlob()
    {
        CheckMoveDirection();
        transform.position += movementVector * moveSpeed * Time.deltaTime;
    }
    private void CheckMoveDirection()
    {
        int positionRounded = Mathf.RoundToInt(transform.localPosition.x);
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
        transform.rotation = newRotation;
    }
}

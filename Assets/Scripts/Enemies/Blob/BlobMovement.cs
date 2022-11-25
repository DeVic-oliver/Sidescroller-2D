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
        TreatXRangeUnits();
        localMinRangeLimit = Mathf.RoundToInt(transform.localPosition.x) - MinRangeLimit;
        localMaxRangeLimit = Mathf.RoundToInt(transform.localPosition.x) + MaxRangeLimit;
    }
    private void TreatXRangeUnits()
    {
        if(MinRangeLimit < 0)
        {
            MinRangeLimit *= -1;
        }
        if(MaxRangeLimit < 0)
        {
            MaxRangeLimit *= -1;
        }
    }
    void Update()
    {
        MoveBlob();
    }
    private void MoveBlob()
    {
        CheckMoveDirection();
        Vector3 position = movementVector * moveSpeed * Time.deltaTime;
        Debug.Log(position);
        transform.Translate(position);
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
        if (positionRounded < localMinRangeLimit)
        {
            ChangeMovementDirection(MovementDirection.Right);
            ChangeMovement(Vector3.right);
            RotateBlob(180);
        }
    }
    private void CheckIfReachedAtMaximumRangeLimit(int positionRounded)
    {
        if (positionRounded > localMaxRangeLimit)
        {
            Debug.Log("checando max range limit");

            ChangeMovementDirection(MovementDirection.Left);
            RotateBlob(0);
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
    private void RotateBlob(float value = 180)
    {
        Vector3 eulers = Vector3.up * value;
        transform.Rotate(eulers, Space.Self);
    }
}

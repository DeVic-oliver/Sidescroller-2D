using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemies/Blob", fileName = "SCO_BlobData", order = 0)]
public class BlobData : ScriptableObject
{
    [Header("Blob Data Setup")]
    public int HealthPoints;
    [Header("Movement Settings")]
    public int MinMoveRangeLimit;
    public int MaxMoveRangeLimit;
    public float MoveSpeed;
}

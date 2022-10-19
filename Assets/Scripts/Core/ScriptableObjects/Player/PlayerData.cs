using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Player", fileName = "SCO_PlayerData", order = 0)]
public class PlayerData : ScriptableObject
{
    [Header("Player Data Setup")]
    public float MoveSpeed;
    public float JumpForce;
    public float RunSpeed;
}

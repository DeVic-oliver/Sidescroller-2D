using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Player", fileName = "SCO_PlayerData", order = 0)]
public class PlayerData : CharactersStatusBaseData
{
    [Header("Player Data Setup")]
    public float JumpForce;
    public float RunSpeed;
}

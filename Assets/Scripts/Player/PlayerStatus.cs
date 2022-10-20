using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamageable
{
    private bool isAlive;
    [SerializeField] private PlayerData _playerData;
    // Start is called before the first frame update
    private void Awake()
    {
        InitPlayerData();
    }
    private void InitPlayerData()
    {
        isAlive = _playerData.IsAlive;
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Returns a bool value if player is alive. Default is true!
    /// </summary>
    /// <returns>true is alive | false is dead</returns>
    public bool GetPlayerAliveStatus()
    {
        return isAlive;
    }
    /// <summary>
    /// Sets the player Alive Status to true and resurrect the player!
    /// </summary>
    public void ResurrectPlayer()
    {
        isAlive = true;
    }
    /// <summary>
    /// Sets the player Alive Status to false and kills the player!
    /// </summary>
    public void KillPlayer()
    {
        isAlive = false;
    }

    public void ApplyDamage()
    {
        KillPlayer();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Player : MonoBehaviour, IDamageable
{
    public bool IsAlive { get; set; }
    public int HealthPoints { get; private set; }
    private PlayerMovement _playerMovements;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        GetRequiredComponents();
        InitObjects();
    }
    private void GetRequiredComponents()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void InitObjects()
    {
        _playerMovements = new PlayerMovement(_playerData, _rigidbody);
    }
    void Start()
    {
        IsAlive = true;
        HealthPoints = _playerData.HealthPoints;
    }
    void Update()
    {
        IsAlive = CheckIfPlayerStillAlive();
        _playerMovements.Move(IsAlive);
    }
    private bool CheckIfPlayerStillAlive()
    {
        if(HealthPoints <= 0)
        {
            return false;
        }
        return true;
    }
    private void FixedUpdate()
    {
    }
    public void ApplyDamage(int damageValue)
    {
        int damageValueTreated = TreatedDamageValue(damageValue);
        if(damageValueTreated >= HealthPoints)
        {
            HealthPoints = 0;
        }
        else
        {
            HealthPoints -= damageValueTreated;
        }
    }
    private int TreatedDamageValue(int damageValue)
    {
        if(damageValue <= 0)
        {
            return 0;
        }
        return damageValue;
    }
}

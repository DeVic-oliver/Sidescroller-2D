using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core.Interfaces;
using Assets.Player;
[RequireComponent(typeof (Rigidbody2D))]
public class Player : MonoBehaviour, IDamageable
{
    public bool IsAlive { get; set; }
    public int HealthPoints { get; private set; }
    [SerializeField] private PlayerData _playerData;
    private PlayerMovement _playerMovements;
    private Rigidbody2D _rigidbody;
    private PlayerAnimationManager _playerAnimationManager;

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
        _playerAnimationManager = new PlayerAnimationManager(GetComponent<Animator>(), _rigidbody);
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
        WatchPlayerAnimations();
    }
    private void WatchPlayerAnimations()
    {
        _playerAnimationManager.WatchMovingAnimation();
        _playerAnimationManager.WatchingAirAnimation();
        _playerAnimationManager.WatchLifeAnimation(IsAlive);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ICollectable collectable = collision.gameObject.GetComponent<ICollectable>();
        if(collectable != null)
        {
            collectable.ApplyPoint();
        }
    }
}

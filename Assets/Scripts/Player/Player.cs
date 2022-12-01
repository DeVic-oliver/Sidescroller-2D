using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
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
    // Start is called before the first frame update
    void Start()
    {
        IsAlive = true;
        HealthPoints = _playerData.HealthPoints;
    }
    // Update is called once per frame
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
        Debug.Log(IsAlive);
    }
}

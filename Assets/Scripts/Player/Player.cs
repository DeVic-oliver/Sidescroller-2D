using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Core.Classes.Static;
using Scripts.Utils._2D;

namespace Assets.Scripts.PlayerComponent
{
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
            IsAlive = LifeStatusParser.GetLifeStatusBasedOnHealth(HealthPoints);
            _playerMovements.Move(IsAlive);
            _playerMovements.IsGrounded = JumpRaycaster2D.CheckIfIsGrounded(GetComponent<Collider2D>());
            WatchPlayerAnimations();
        }
        private void WatchPlayerAnimations()
        {
            _playerAnimationManager.WatchMovingAnimation();
            _playerAnimationManager.WatchingAirAnimation();
            _playerAnimationManager.WatchLifeAnimation(IsAlive);
        }

        private void FixedUpdate()
        {
        }

        public void ApplyDamage(int damageValue)
        {
            int damageValueTreated = TreatNegativeNumber.GetTreatedValue(damageValue);
            if(damageValueTreated >= HealthPoints)
            {
                HealthPoints = 0;
            }
            HealthPoints -= damageValueTreated;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ICollectable collectable = collision.gameObject.GetComponent<ICollectable>();
            if(collectable != null)
            {
                collectable.ApplyPoint();
            }
        }
    }
}


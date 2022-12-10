using System.Collections;
using UnityEngine;
using Scripts.Utils._2D;

namespace Assets.Scripts.Player
{
    public class PlayerParticles : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _runDustParticleSystem;
        [SerializeField] private ParticleSystem _jumpDustParticleSystem;

        private int _jumpParticleShots = 0;
        private bool _hasJumped;

        // Use this for initialization
        void Start()
        {
            ChangeParticleEmission(_runDustParticleSystem, 0);
        }

        // Update is called once per frame
        void Update()
        {
            bool isGrounded = JumpRaycaster2D.CheckIfIsGrounded(GetComponent<Collider2D>());

            if (isGrounded)
            {
                ChangeParticleEmission(_runDustParticleSystem ,3);
                _jumpParticleShots = 0;
                _hasJumped = false;
            }
            else
            {
                ChangeParticleEmission(_runDustParticleSystem, 0);
            }

            var _rigidbody = GetComponent<Rigidbody2D>();

            if(_rigidbody.velocity.y > 0 && !isGrounded)
            {
                PlayParticleOneShot(_jumpDustParticleSystem);
            }
        }

        private void ChangeParticleEmission(ParticleSystem particleSystem, float value)
        {
            var emission = particleSystem.emission;
            emission.rateOverDistance = value;
        }

        private void PlayParticleOneShot(ParticleSystem particleSystem)
        {
            if(_jumpParticleShots == 0 && !_hasJumped)
            {
                particleSystem.Play();
                _jumpParticleShots = 1;
            }
            else
            {
                particleSystem.Stop();
            }
        }

    }
}
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerJumpAudioPlay : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private bool _audioPlayed;

        private void Update()
        {
            if(GetComponent<Rigidbody2D>().velocity.y > 0 && !_audioPlayed)
            {
                _audioPlayed = true;
                PlayAudio();
            }

            if(GetComponent<Rigidbody2D>().velocity.y == 0 && _audioPlayed)
            {
                _audioPlayed = false;
            }
        }

        public void PlayAudio()
        {
            _audioSource.Play();
        }
    }
}
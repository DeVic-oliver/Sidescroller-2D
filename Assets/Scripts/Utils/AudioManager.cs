using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class AudioManager
    {
        public static void PlayAudio(AudioSource audioSource)
        {
            audioSource.Play();
        }
    }
}
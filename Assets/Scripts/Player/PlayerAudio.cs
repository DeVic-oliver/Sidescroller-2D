using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public List<AudioClip> _audioClipList;

    public List<AudioSource> _audioSourceList;

    public void PlayAudio()
    {
        var audioSource = _audioSourceList[Random.Range(0, _audioSourceList.Count)];
        audioSource.clip = _audioClipList[Random.Range(0, _audioClipList.Count)];
        audioSource.Play();
    }
}

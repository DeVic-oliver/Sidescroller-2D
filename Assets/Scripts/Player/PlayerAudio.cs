using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    private AudioSource _audioSource;

    public List<AudioClip> _audioClipList;

    public List<AudioSource> _audioSourceList;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        var audioSource = _audioSourceList[Random.Range(0, _audioSourceList.Count)];
        audioSource.clip = _audioClipList[Random.Range(0, _audioClipList.Count)];
        audioSource.Play();
    }
}

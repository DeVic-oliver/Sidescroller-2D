using System.Collections;
using UnityEngine;
using Assets.Scripts.Core.Interfaces;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour, ICollectable
{
    public static int CoinsCollected = 0;
    [SerializeField] private SOCoin soCoin;
    private ParticleSystem _particleSystem;
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;
    private float secondsToDisable = 2f;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CircleCollider2D>();
        _audioSource = GetComponent<AudioSource>();
    }
    public void ApplyPoint()
    {
        CoinsCollected += soCoin.CoinValue;
        _collider.enabled = false;
        _spriteRenderer.enabled = false;
        _particleSystem.Play();
        _audioSource.Play();
        StartCoroutine("DisableMe");
    }
    private IEnumerator DisableMe()
    {
        yield return new WaitForSeconds(secondsToDisable);
        gameObject.SetActive(true);
    }
}

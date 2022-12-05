using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Core.Interfaces;
using DG.Tweening;
public class BlobStatus : MonoBehaviour, IDamageable
{
    public int HealthPoints { get; }
    public bool IsAlive { get; set; }
    public Color damagedColor;
    private Color normalColor = Color.white;
    [SerializeField] private int healthPoints;
    private SpriteRenderer _spriteRenderer;
    private string childName = "Body";
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = transform.Find(childName).gameObject.GetComponent<SpriteRenderer>();
        IsAlive = true;
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsAlive", true);
    }
    // Update is called once per frame
    void Update()
    {
        if(healthPoints <= 0)
        {
            _animator.SetBool("IsAlive", false);
            GetComponent<CapsuleCollider2D>().enabled = false;
            Destroy(gameObject, 5f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IInstaKillable instaKillable = collision.gameObject.GetComponent<IInstaKillable>();
        if (instaKillable != null)
        {
            _animator.SetTrigger("Attack");
            instaKillable.ApplyInstaKill();
        }
    }
    public void ApplyDamage(int damageValue)
    {
        StartCoroutine(ApplyDamageEffect());
        if( damageValue < 0)
        {
            damageValue = 0;
        }
        healthPoints -= damageValue;
    }
    private IEnumerator ApplyDamageEffect()
    {
        _spriteRenderer.material.color = Color.Lerp(normalColor, damagedColor, 1);
        yield return new WaitForSeconds(.1f);
        _spriteRenderer.material.color = Color.Lerp(damagedColor, normalColor, 1);
    }
}

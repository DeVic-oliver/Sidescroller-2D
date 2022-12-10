using System.Collections;
using UnityEngine;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Core.Classes.Static;
public class Blob : MonoBehaviour, IDamageable
{
    public bool IsAlive { get; set; }
    public int HealthPoints { get; private set; }

    [SerializeField] private BlobData blobData;
    [SerializeField] private Color damagedColor;
    private Color normalColor = Color.white;
    
    private IMoveable blobMovements;
    private SpriteRenderer _spriteRenderer;
    private string childName = "Body";
    private Animator _animator;


    public void ApplyDamage(int damageValue)
    {
        int damage = TreatNegativeNumber.GetTreatedValue(damageValue);
        StartCoroutine(ApplyDamageEffect());
        if (damage >= HealthPoints)
        {
            HealthPoints = 0;
        }
        HealthPoints -= damage;
    }
    private IEnumerator ApplyDamageEffect()
    {
        _spriteRenderer.material.color = Color.Lerp(normalColor, damagedColor, 1);
        yield return new WaitForSeconds(.1f);
        _spriteRenderer.material.color = Color.Lerp(damagedColor, normalColor, 1);
    }

    void Start()
    {
        InitObjects();
        _spriteRenderer = transform.Find(childName).gameObject.GetComponent<SpriteRenderer>();
        HealthPoints = blobData.HealthPoints;
        IsAlive = true;
        _animator.SetBool("IsAlive", true);
    }
    private void InitObjects()
    {
        blobMovements = new BlobMovement(blobData.MoveSpeed, blobData.MinMoveRangeLimit, blobData.MaxMoveRangeLimit, transform);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IsAlive = LifeStatusParser.GetLifeStatusBasedOnHealth(HealthPoints);
        blobMovements.Move(IsAlive);

        if (!IsAlive)
        {
            _animator.SetBool("IsAlive", false);
            GetComponent<Collider2D>().enabled = false;
            Invoke("DisableGameObject", 3f);
        }
    }
    private void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            _animator.SetTrigger("Attack");
            damageable.ApplyDamage(2);
        }
    }
}

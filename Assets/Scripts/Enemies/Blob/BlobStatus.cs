using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Interfaces.General;

public class BlobStatus : MonoBehaviour, IDamageable
{
    [SerializeField] private int healthPoints;
    public bool IsAlive { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        IsAlive = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IInstaKillable instaKillable = collision.gameObject.GetComponent<IInstaKillable>();
        if (instaKillable != null)
        {
            instaKillable.ApplyInstaKill();
        }
    }
    public void ApplyDamage(int damageValue)
    {
        if( damageValue < 0)
        {
            damageValue = 0;
        }
        healthPoints -= damageValue;
    }
}

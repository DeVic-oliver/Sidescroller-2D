using System.Collections;
using UnityEngine;
namespace Player.Weapon
{
    public class WeaponBullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private int baseDamage;
        private float timeToAutoDestroy = 2;
        // Update is called once per frame
        void Update()
        {
            FlyStraightFoward();
            DestroyMeAfterTime(timeToAutoDestroy);
        }
        private void FlyStraightFoward()
        {
            transform.localPosition += Vector3.right * speed * Time.deltaTime;
        }
        private void DestroyMeAfterTime(float timeToDestroy)
        {
            Destroy(gameObject, timeToDestroy);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            IDamageable damageable = GetComponent<IDamageable>();
            if(damageable != null)
            {
                damageable.ApplyDamage(baseDamage);
            }
        }
    }
}
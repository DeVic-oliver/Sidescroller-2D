using System.Collections;
using UnityEngine;
namespace Player.Weapon
{
    public class WeaponBullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private int baseDamage;
        private float timeToAutoDestroy = 2;
        private Vector3 movementVector = Vector3.right;

        public void ChangeMovementVectorTo(Vector3 moveVector)
        {
            movementVector = moveVector;
        }
        // Update is called once per frame
        void Update()
        {
            FlyStraightFoward();
            DestroyMeAfterTime(timeToAutoDestroy);
        }
        private void FlyStraightFoward()
        {
            transform.Translate(movementVector * speed * Time.deltaTime);
        }
        private void DestroyMeAfterTime(float timeToDestroy)
        {
            Destroy(gameObject, timeToDestroy);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if(damageable != null)
            {
                damageable.ApplyDamage(baseDamage);
                Destroy(gameObject);
            }
        }
       
    }
}
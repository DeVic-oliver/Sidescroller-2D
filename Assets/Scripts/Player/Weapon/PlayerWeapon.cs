using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player.Weapon
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private WeaponBullet bullet;
        [SerializeField] private Transform weaponHolder;
        void Update()
        {
            CheckPlayerLookingSide();
            FireWeapon();
        }
        private void FireWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(bullet, transform.position, transform.rotation);
            }
        }
        private void CheckPlayerLookingSide()
        {
            if (weaponHolder.rotation.y == 0)
            {
                bullet.ChangeMovementVectorTo(Vector3.right);
            }
            else if (weaponHolder.rotation.y == 1)
            {
                bullet.ChangeMovementVectorTo(Vector3.left);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player.Weapon
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private WeaponBullet bullet;

        void Update()
        {
            FireWeapon();
        }
        private void FireWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Instantiate(bullet, transform.position, transform.rotation);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.PlayerComponent
{
    [RequireComponent(typeof(Player))]
    public class Pistol : MonoBehaviour
    {
        private Player weaponHolder;
        private WeaponBullet _bullet;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Transform weaponPosition;
        [SerializeField] private GameObject bulletPrefab;

        private void Start()
        {
            InitComponentsObject();
            SetBulletPrefabScript();
        }
        private void InitComponentsObject()
        {
            weaponHolder = GetComponent<Player>();
        }
        private void SetBulletPrefabScript()
        {
            if (bulletPrefab.GetComponent<WeaponBullet>() == null)
            {
                bulletPrefab.AddComponent<WeaponBullet>();
            }
            else
            {
                _bullet = bulletPrefab.GetComponent<WeaponBullet>();
            }
        }

        void Update()
        {
            CheckPlayerLookingSide();
            FireWeapon();
        }
        private void FireWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && weaponHolder.IsAlive)
            {
                _audioSource.Play();
                Instantiate(_bullet, weaponPosition.transform.position, weaponPosition.transform.rotation);
            }
        }
        private void CheckPlayerLookingSide()
        {
            if (weaponHolder.transform.rotation.y == 0)
            {
                _bullet.ChangeMovementVectorTo(Vector3.right);
            }
            else if (weaponHolder.transform.rotation.y == 1)
            {
                _bullet.ChangeMovementVectorTo(Vector3.left);
            }
        }
    }

}
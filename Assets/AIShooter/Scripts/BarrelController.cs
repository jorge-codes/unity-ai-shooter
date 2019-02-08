using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarrelController : MonoBehaviour
{
    [SerializeField] protected float _bulletSpeed = 4f;
    [SerializeField] protected float _bulletLifeTime = 3f;
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Transform _mountPoint;

    public void Shoot()
    {
        
        GameObject obj = Instantiate(_bulletPrefab);
        BulletController bullet = obj.GetComponent<BulletController>();
        bullet.Setup(_mountPoint, _bulletSpeed, _bulletLifeTime);
    }

    private void Start()
    {
        if (_mountPoint == null)
        {
            _mountPoint = transform;
        }
    }

}

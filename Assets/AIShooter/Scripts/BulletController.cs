using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _speed;
    private Vector3 _direction;
    private float _lifeTime;
    private float _timer;
    
    public void Setup(Vector3 origin, Vector3 direction, float speed, float lifeTime = 3f)
    {
        _direction = direction;
        _speed = speed;
        transform.position = origin;
        transform.LookAt(transform.position + _direction);
        _lifeTime = lifeTime;
        _timer = 0f;
    }

    public void Setup(Transform mountPoint, float speed, float lifeTime = 3f)
    {
        transform.position = mountPoint.position;
        _direction = mountPoint.forward;
        _speed = speed;
        _lifeTime = lifeTime;
        transform.LookAt(transform.position + _direction);
        _timer = 0f;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer >= _lifeTime)
        {
            Destroy(gameObject);
        }
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        _timer += Time.deltaTime;
    }
}

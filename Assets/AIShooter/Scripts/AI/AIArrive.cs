﻿using UnityEngine;

public class AIArrive : MonoBehaviour
{
    [SerializeField] private float _stopRadius;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;
    private Vector3 _direction;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
            return;
        _direction = _target.position - transform.position;
    }

    private void FixedUpdate()
    {
        if (_target == null)
            return;
        if (_direction.magnitude <= _stopRadius)
            return;
        
        _direction.Normalize();
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        transform.LookAt(_target);
    }
}
﻿using UnityEngine;

public class AIAgent : MonoBehaviour
{
    public Transform Target
    {
        get { return _target; }
    }

    public Vector3 Velocity
    {
        get { return _velocity; }
    }
    
    [SerializeField] protected float _speed;
    [SerializeField] protected Transform _target;
    protected Vector3 _velocity;
    protected float _angular;

    private AIBehavior _behavior;
        
    // Start is called before the first frame update
    protected virtual void Start()
    {
        _velocity = Vector3.zero;
        _behavior = GetComponent<AIBehavior>();
        if (_behavior != null)
        {
            _behavior.Init(this);
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_behavior == null)
            return;

        Steering steering = _behavior.GetSteering();
        _velocity = steering.linear;
        _angular = steering.angular;
    }

    protected virtual void FixedUpdate()
    {
        transform.Translate(_velocity * _speed * Time.deltaTime, Space.World);
        // TODO this is temporary (remove)
        transform.LookAt(transform.position + _velocity);
    }

}

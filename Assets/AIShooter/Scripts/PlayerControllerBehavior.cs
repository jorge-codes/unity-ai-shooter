using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBehavior : AIBehavior
{
    [SerializeField] protected Camera _camera;
    [SerializeField] protected Animator _animator;
    protected float _newMagnitude;
    protected float _oldMagnitude;
    
    public override void Init(AIAgent agent)
    {
        base.Init(agent);
        _oldMagnitude = 0f;
        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    void Update()
    {
        float cameraRotation = _camera.transform.eulerAngles.y;
        _steering.linear.x = Input.GetAxis("Horizontal");
        _steering.linear.z = Input.GetAxis("Vertical");
        _steering.linear = Quaternion.AngleAxis(cameraRotation, Vector3.up) * _steering.linear;
        _steering.linear.Normalize();

        _newMagnitude = _steering.linear.magnitude;
        CheckWalkState();
        _oldMagnitude = _newMagnitude;
    }

    private void CheckWalkState()
    {
        if (_animator == null) return;
        
        if (_newMagnitude != _oldMagnitude)
        {
            if (_newMagnitude == 0f)
            {
                _animator.SetBool("walk", false);
            }
            else
            {
                _animator.SetBool("walk", true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPursue : AISeek
{
    public float predictionRange;
    private Transform _dummyTarget;
    private PlayerController _player;

    public override void Init(AIAgent agent)
    {
        base.Init(agent);
        GameObject dummy = new GameObject();
        dummy.name = "Dummy object (pursue)";
        _dummyTarget = dummy.transform;
        _target = _dummyTarget;
        // TODO remove hardwired code
        _player = _agent.Target.gameObject.GetComponent<PlayerController>();
    }

    public override Steering GetSteering()
    {
        if (_agent == null || _agent.Target == null)
            return new Steering();
     
        _steering.Restore();
        _dummyTarget.position = _agent.Target.position;
        _dummyTarget.position += _player.Velocity * predictionRange;
        _target = _dummyTarget;
        return base.GetSteering();
    }

    private void OnDrawGizmos()
    {
        if (_dummyTarget == null)
            return;
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(_dummyTarget.position, 0.5f);
    }
}

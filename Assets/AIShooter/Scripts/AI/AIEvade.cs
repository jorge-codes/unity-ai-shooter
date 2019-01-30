using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEvade : AIFlee
{
    public float predictionRange;
    private Transform _dummyTarget;
    private AIAgent _targetAgent;

    public override void Init(AIAgent agent)
    {
        base.Init(agent);
        GameObject dummy = new GameObject();
        dummy.name = "Dummy object (evade)";
        _dummyTarget = dummy.transform;
        _target = _dummyTarget;
        
        _targetAgent = _agent.Target.gameObject.GetComponent<AIAgent>();
    }

    public override Steering GetSteering()
    {
        if (_agent == null || _agent.Target == null)
            return new Steering();
     
        _steering.Restore();
        _dummyTarget.position = _agent.Target.position;
        _dummyTarget.position += _targetAgent.Velocity * predictionRange;
        _target = _dummyTarget;
        return base.GetSteering();
    }

    private void OnDrawGizmos()
    {
        if (_dummyTarget == null)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_dummyTarget.position, 0.5f);
    }
}

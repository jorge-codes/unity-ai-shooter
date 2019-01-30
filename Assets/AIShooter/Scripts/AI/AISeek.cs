using UnityEngine;

[RequireComponent(typeof(AIAgent))]
public class AISeek : AIBehavior
{
    protected Transform _target;
    public override void Init(AIAgent agent)
    {
        base.Init(agent);
        _target = agent.Target;
    }

    public override Steering GetSteering()
    {
        if (_agent == null || _agent.Target == null)
            return _steering;
        
        _steering.Restore();
        _steering.linear = _target.position - transform.position;
        _steering.linear.Normalize();
        
        return _steering;
    }
}

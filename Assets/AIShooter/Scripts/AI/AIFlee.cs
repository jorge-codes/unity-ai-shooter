using UnityEngine;

[RequireComponent(typeof(AIAgent))]
public class AIFlee : AIBehavior
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
        _steering.linear = transform.position - _target.position;
        _steering.linear.Normalize();
        
        return _steering;
    }
}

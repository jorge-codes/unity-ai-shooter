using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBehavior : MonoBehaviour
{
    protected Steering _steering;
    protected AIAgent _agent;
    
    public virtual void Init(AIAgent agent)
    {
        _steering = new Steering();
        _agent = agent;
    }
    
    public virtual Steering GetSteering()
    {
        _steering.Restore();
        return _steering;
    }

}

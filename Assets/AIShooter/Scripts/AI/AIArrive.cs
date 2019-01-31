using UnityEngine;

public class AIArrive : AISeek
{
    [SerializeField] protected float _stopRadius;

    public override Steering GetSteering()
    {
        float distance = Vector3.Distance(_target.position, transform.position);
        _steering = base.GetSteering();
        if (distance <= _stopRadius)
        {
            _steering.Restore();
        }

        return _steering;
    }
}
